using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Web.DataAccess.Repository;
using Web.DataAccess.Repository.Interface;
using Web.DataAccess.ViewModel;
using Web.Models;

namespace WebForm_final.Areas.Customer.Controllers
{
    [Authorize]
    [Area("Customer")]
    public class CartController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ShoppingCartViewModel shoppingCartVM;
        public CartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var UserId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            shoppingCartVM = new()
            {
                ListCart = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == UserId, includeProperties: "Product"),
            };
            foreach (var listProduct in shoppingCartVM.ListCart)
            {
                listProduct.price = getPrice(listProduct);
                shoppingCartVM.TotalPrice += (listProduct.price * listProduct.Quantity);
            }
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
            return View();
        }
    }

}
