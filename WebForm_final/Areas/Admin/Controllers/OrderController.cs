using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using System.Diagnostics;
using System.Security.Claims;
using Web.DataAccess.Migrations;
using Web.DataAccess.Repository;
using Web.DataAccess.Repository.Interface;
using Web.DataAccess.ViewModel;
using Web.Models;
using Web.Utility;

namespace WebForm_final.Areas.Admin.Controllers
{
	[Authorize(Roles = Global.Role_user_admin)]
	[Area("Admin")]
	public class OrderController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		[BindProperty]
		public OrderViewModel orderVM { get; set; }
        public OrderController(IUnitOfWork unitOfWork)
        {
			_unitOfWork = unitOfWork;

		}
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Details(int Orderid)
		{
			 orderVM = new()
			{
				Order = _unitOfWork.Order.Get(u => u.Id == Orderid, includeProperties: "ApplicationUser"),
				OrderDetail = _unitOfWork.OrderDetail.GetAll(u => u.OrderId == Orderid, includeProperties: "Product")

			};
			return View(orderVM);
		}
		[Authorize(Roles =Global.Role_user_admin)]
		[HttpPost]
        public IActionResult UpdateOrderDetail(int Orderid)
        {
			var OrderVMFromDb = _unitOfWork.Order.Get(u => u.Id == orderVM.Order.Id);

            OrderVMFromDb.StreetAdress = orderVM.Order.StreetAdress;
            OrderVMFromDb.Name = orderVM.Order.Name;
            OrderVMFromDb.City = orderVM.Order.City;
            OrderVMFromDb.Province = orderVM.Order.Province;
            OrderVMFromDb.PhoneNumber = orderVM.Order.PhoneNumber;
			_unitOfWork.Order.update(OrderVMFromDb);
			_unitOfWork.Order.save();
			TempData["notification"] = "Order Details Updated Successfully";		
            return RedirectToAction(nameof(Details), new { Orderid = OrderVMFromDb.Id});
        }
        [HttpPost]
        [Authorize(Roles = Global.Role_user_admin)]
        public IActionResult ShipOrder()
        {
            _unitOfWork.Order.UpdateStatus(orderVM.Order.Id, Global.Status_shipped);
            _unitOfWork.Order.save();
            TempData["notification"] = "Order Status Updated Successfully";
            return RedirectToAction(nameof(Details), new { Orderid = orderVM.Order.Id });
        }

        [HttpPost]
        [Authorize(Roles = Global.Role_user_admin + "," + Global.Role_user_customer)]
        public IActionResult CancelOrder()
        {
			 var obj = _unitOfWork.Order.Get(u => u.Id == orderVM.Order.Id);
			if(obj.PaymentStatus == Global.Payment_paid)
			{
				var options = new RefundCreateOptions
				{
					Reason = RefundReasons.RequestedByCustomer,
					PaymentIntent = obj.PaymentItentId
				};
				var service = new RefundService();
				Refund refund = service.Create(options);
				_unitOfWork.Order.UpdateStatus(obj.Id, Global.Status_canclled, Global.Payment_refunded);
            }
            else
			{
                _unitOfWork.Order.UpdateStatus(orderVM.Order.Id, Global.Status_canclled, Global.Status_canclled);
            }
            _unitOfWork.Order.save();
            TempData["notification"] = "Order Cancelled Successfully";
            return RedirectToAction(nameof(Details), new { Orderid = orderVM.Order.Id });
        }

        [HttpPost]
		[Authorize(Roles =Global.Role_user_admin)]
		public IActionResult StartProcessing() 
		{ 
			_unitOfWork.Order.UpdateStatus(orderVM.Order.Id, Global.Status_inProgress);
			_unitOfWork.Order.save();
			TempData["notification"] = "Order Status Updated Successfully";
			return RedirectToAction(nameof(Details), new { Orderid = orderVM.Order.Id});
		}

        #region API CALLS

        [HttpGet]
		public IActionResult GetAll(string status)
		{
			IEnumerable<Order> allObj;

			if (User.IsInRole(Global.Role_user_admin))
			{
                allObj= _unitOfWork.Order.GetAll(includeProperties: "ApplicationUser").ToList();
            }
			else
			{
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var UserId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
				allObj = _unitOfWork.Order.GetAll(u=> u.ApplicationUserId == UserId, includeProperties: "ApplicationUser");
            }

			switch (status)
			{
				case "pending":
					allObj = allObj.Where(u=> u.orderStatus == Global.Status_pending);
					break;
				case "inprocess":
					allObj = allObj.Where(u => u.orderStatus == Global.Status_inProgress);
					break;
				case "completed":
					allObj = allObj.Where(u => u.orderStatus == Global.Status_complete);
					break;
				case "approved":
					allObj = allObj.Where(u => u.orderStatus == Global.Status_approved);		
						break;
				default:
					break;

			}
			return Json(new { data = allObj });
		}
		#endregion
	}
}
