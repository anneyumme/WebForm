using Microsoft.AspNetCore.Mvc;
using WebForm_final.Data;
using WebForm_final.Models;

namespace WebForm_final.Controllers
{
    public class BrandController : Controller
    {
        readonly ApplicationDbContext _db; 
        public BrandController(ApplicationDbContext db)
        {
            _db = db;   
        }
        public IActionResult Index()
        {
            List<Brand> objbrands = _db.Brands.ToList();
            return View(objbrands);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Brand objbrand)
        {
            //if(objbrand.name == null )
            //{
            //    ModelState.AddModelError("name", "Brand Name is required");
            //    return View();
            //}
            if(ModelState.IsValid)
            {
                _db.SaveChanges();
                _db.Brands.Add(objbrand);
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
