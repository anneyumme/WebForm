using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;
using System.Security.Claims;
using Web.DataAccess.Repository;
using Web.DataAccess.Repository.Interface;
using Web.DataAccess.ViewModel;
using Web.Models;
using Web.Utility;

namespace WebForm_final.Areas.Customer.Controllers
{
	[Area("Customer")]
	[Authorize]
	public class CartController : Controller
	{

		private readonly IUnitOfWork _unitOfWork;
		private readonly IEmailSender _emailSender;
		[BindProperty]  //bind all the property shoppingCartVM variable with the view when submit
		public ShoppingCartViewModel shoppingCartVM { get; set; }
		public CartController(IUnitOfWork unitOfWork, IEmailSender emailSender)
		{
			_unitOfWork = unitOfWork;
			_emailSender = emailSender;

		}
		public IActionResult Index()
		{
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var UserId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

			shoppingCartVM = new()
			{
				ListCart = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == UserId, includeProperties: "Product"),
				Order = new Order()
			};
			foreach (var listProduct in shoppingCartVM.ListCart)
			{
				listProduct.price = getPrice(listProduct);
				shoppingCartVM.Order.OrderTotal += (listProduct.price * listProduct.Quantity);
			}
			HttpContext.Session.SetInt32("CartCount", shoppingCartVM.ListCart.Count());
			return View(shoppingCartVM);
		}
		private double getPrice(ShoppingCart shoppingCart)
		{
			if (shoppingCart.Quantity <= 50)
			{
				return shoppingCart.Product.price;
			}
			else if (shoppingCart.Quantity <= 100 && shoppingCart.Quantity > 50)
			{
				return shoppingCart.Product.price50;
			}
			else
			{
				return shoppingCart.Product.price100;
			}
		}
		public IActionResult Plus(int cartId)
		{
			var cartFromDb = _unitOfWork.ShoppingCart.Get(u => u.Id == cartId);
			cartFromDb.Quantity += 1;
			_unitOfWork.ShoppingCart.update(cartFromDb);
			_unitOfWork.ShoppingCart.save();
			return RedirectToAction(nameof(Index));
		}
		public IActionResult Minus(int cartId)
		{
			ShoppingCart cartFromDb = _unitOfWork.ShoppingCart.Get(u => u.Id == cartId);
			if (cartFromDb.Quantity == 1)
			{
				_unitOfWork.ShoppingCart.remove(cartFromDb);
			}
			else
			{
				cartFromDb.Quantity -= 1;
				_unitOfWork.ShoppingCart.update(cartFromDb);
			}
			_unitOfWork.ShoppingCart.save();
			return RedirectToAction(nameof(Index));
		}
		public IActionResult Delete(int cartId)
		{
			ShoppingCart cartFromDb = _unitOfWork.ShoppingCart.Get(u => u.Id == cartId, includeProperties: "Product");
			_unitOfWork.ShoppingCart.remove(cartFromDb);
			_unitOfWork.ShoppingCart.save();
			return RedirectToAction(nameof(Index));

		}
		public IActionResult Summary()
		{
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var UserId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

			shoppingCartVM = new()
			{
				ListCart = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == UserId, includeProperties: "Product"),
				Order = new()
			};

			shoppingCartVM.Order.ApplicationUser = _unitOfWork.userApplication.Get(u => u.Id == UserId);

			shoppingCartVM.Order.StreetAdress = shoppingCartVM.Order.ApplicationUser.StreetAdress;
			shoppingCartVM.Order.Name = shoppingCartVM.Order.ApplicationUser.FullName;
			shoppingCartVM.Order.City = shoppingCartVM.Order.ApplicationUser.City;
			shoppingCartVM.Order.Province = shoppingCartVM.Order.ApplicationUser.Province;
			shoppingCartVM.Order.PhoneNumber = shoppingCartVM.Order.ApplicationUser.PhoneNumber;

			foreach (var listProduct in shoppingCartVM.ListCart)
			{
				listProduct.price = getPrice(listProduct);
				shoppingCartVM.Order.OrderTotal += (listProduct.price * listProduct.Quantity);
			}

			return View(shoppingCartVM);
		}
		[HttpPost]
		[ActionName("Summary")]
		public IActionResult SummaryPOST()
		{
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var UserId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

			shoppingCartVM.ListCart = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == UserId, includeProperties: "Product");

			shoppingCartVM.Order.ApplicationUser = _unitOfWork.userApplication.Get(u => u.Id == UserId);
			shoppingCartVM.Order.OrderCreate = System.DateTime.Now;
			shoppingCartVM.Order.ApplicationUserId = UserId;

			foreach (var listProduct in shoppingCartVM.ListCart)
			{
				listProduct.price = getPrice(listProduct);
				shoppingCartVM.Order.OrderTotal += (listProduct.price * listProduct.Quantity);
			}
			shoppingCartVM.Order.PaymentStatus = Global.Payment_pending;
			shoppingCartVM.Order.orderStatus = Global.Status_pending;
			_unitOfWork.Order.add(shoppingCartVM.Order);
			_unitOfWork.Order.save();

			//Creat order detail after create order

			foreach (var item in shoppingCartVM.ListCart)
			{
				OrderDetail orderDetail = new()
				{
					ProductId = item.ProductId,
					OrderId = shoppingCartVM.Order.Id,
					Price = getPrice(item),
					Quanity = item.Quantity
				};
				_unitOfWork.OrderDetail.add(orderDetail);
				_unitOfWork.OrderDetail.save();
			}

			// Payment
			if (shoppingCartVM.Order.paymentType == "Stripe")
			{
				var domain = "https://localhost:7094/";
				var options = new SessionCreateOptions
				{
					SuccessUrl = domain + $"customer/cart/OrderConfirmation?id={shoppingCartVM.Order.Id}",
					CancelUrl = domain + "customer/cart/index",
					LineItems = new List<SessionLineItemOptions>(),
					Mode = "payment",
				};
				foreach (var item in shoppingCartVM.ListCart)
				{
					var SessionLineItem = new SessionLineItemOptions
					{
						PriceData = new SessionLineItemPriceDataOptions
						{
							UnitAmount = (long)item.price,
							Currency = "vnd",
							ProductData = new SessionLineItemPriceDataProductDataOptions
							{
								Name = item.Product.name
							}
						},
						Quantity = item.Quantity
					};
					options.LineItems.Add(SessionLineItem);
				}
				var service = new SessionService();
				Session session = service.Create(options);
				_unitOfWork.Order.UpdateStripeId(shoppingCartVM.Order.Id, session.Id, session.PaymentIntentId);
				_unitOfWork.Order.save();
				Response.Headers.Add("Location", session.Url);
				return new StatusCodeResult(303);
			}
			
			return RedirectToAction(nameof(OrderConfirmation), new { id = shoppingCartVM.Order.Id });
		}
		public IActionResult OrderConfirmation(int id)
		{
			Order order = _unitOfWork.Order.Get(u=> u.Id == id, includeProperties: "ApplicationUser");
			if(order.paymentType == "Stripe")
			{
				var service = new SessionService();
				Session session = service.Get(order.SessionId);
				if (session.PaymentStatus.ToLower() == "paid")
				{
					_unitOfWork.Order.UpdateStripeId(id, session.Id, session.PaymentIntentId);
					_unitOfWork.Order.UpdateStatus(id, Global.Status_approved, Global.Payment_paid);
					_unitOfWork.Order.save();
				}
			}
            if (order.paymentType == "Cash")
            {
                _unitOfWork.Order.UpdateStatus(id, Global.Status_approved, Global.Payment_NotPaid);
                _unitOfWork.Order.save();
            }
			_emailSender.SendEmailAsync(order.ApplicationUser.Email, "Notification: New Order", $"New Order Created - {order.Id}");
			List<ShoppingCart> shoppingCarts = _unitOfWork.ShoppingCart.GetAll(u=> u.ApplicationUserId == order.ApplicationUserId).ToList();
			_unitOfWork.ShoppingCart.removeRange(shoppingCarts);
			_unitOfWork.ShoppingCart.save();
			TempData["notification"] = "Order Successfully";
			return Redirect("/admin/order");
		}
	}

}
