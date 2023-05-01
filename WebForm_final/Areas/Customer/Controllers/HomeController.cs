using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web.DataAccess.Repository.Interface;
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
			List<Product> productsList = _unitOfWork.Product.GetAll(includeProperties: "brand").ToList();
            return View(productsList);
        }

        public IActionResult Details(int productid)
        {
            Product product = _unitOfWork.Product.Get(u => u.id == productid, includeProperties: "brand");
			return View(product);
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