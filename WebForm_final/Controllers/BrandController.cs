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

		//Edit method
	
		public IActionResult Edit(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			Brand? brandFromDb = _db.Brands.FirstOrDefault(c => c.id == id);
			if (brandFromDb == null)
			{
				return NotFound();
			}
			return View(brandFromDb);
		}
        [HttpPost]
		public IActionResult Edit(Brand objbrand)
		{
		
			if (ModelState.IsValid)
			{
				_db.Brands.Update(objbrand);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View();
		}

		// Create method

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
                _db.Brands.Add(objbrand);
				_db.SaveChanges();
				return RedirectToAction("Index");
            }

            return View();
        }

		// Delete

		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			Brand? brandFromDb = _db.Brands.FirstOrDefault(c => c.id == id);
			if (brandFromDb == null)
			{
				return NotFound();
			}
			return View(brandFromDb);
		}

		[HttpPost]
		public IActionResult Delete123(Brand objbrand)
		{
			_db.Brands.Remove(objbrand);
			_db.SaveChanges();
			return RedirectToAction("index");
		}
	}
}
