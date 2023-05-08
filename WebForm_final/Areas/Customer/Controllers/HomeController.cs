using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.Security.Claims;
using Web.DataAccess.Repository.Interface;
using Web.DataAccess.ViewModel;
using Web.Models;

namespace WebForm_final.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
			if (User.Identity.IsAuthenticated)
            {
				var claimsIdentity = (ClaimsIdentity)User.Identity;
				var UserId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
				ShoppingCartViewModel shoppingCartVM = new()
				{
					ListCart = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == UserId, includeProperties: "Product"),
					Order = new Order()
				};
				HttpContext.Session.SetInt32("CartCount", shoppingCartVM.ListCart.Count());
			}
            else
            {
				HttpContext.Session.SetInt32("CartCount", 0);

			}

			List<Product> productsList = _unitOfWork.Product.GetAll(includeProperties: "brand").ToList();
            List<Brand> brandsList = _unitOfWork.Brand.GetAll().ToList();
            ViewBag.BrandList = brandsList;
            return View(productsList);
        }

        public IActionResult Details(int productid)
        {
            ShoppingCart shoppingCart = new ShoppingCart() {
                Product = _unitOfWork.Product.Get(u => u.id == productid, includeProperties: "brand"),  
				ProductId = productid  
			};
			return View(shoppingCart);
        }
        [HttpPost]
        [Authorize]
        public IActionResult Details(ShoppingCart shoppingCart)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;  // Catch the user claims and store in "claimsIdentity"
			var UserId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value; //  using the FindFirst method, which searches for
            shoppingCart.ApplicationUserId = UserId;                               //  the first claim with a specific claim type the claim type is ClaimTypes.NameIdentifier,
													                              //  which is a standard claim type that represents the user's unique identifier
            ShoppingCart cartFromDb = _unitOfWork.ShoppingCart.Get(u => u.ApplicationUserId == UserId &&
            shoppingCart.ProductId== u.ProductId); 
            if(cartFromDb != null)
            {
                cartFromDb.Quantity += shoppingCart.Quantity;
                _unitOfWork.ShoppingCart.update(cartFromDb);
            }
            else
            {
                _unitOfWork.ShoppingCart.add(shoppingCart);
            }
            
            _unitOfWork.ShoppingCart.save();
            TempData["notification"] = "Cart Updated Successfully";
           
            return RedirectToAction("index");																		
            
		}

		public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}