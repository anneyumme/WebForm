using Microsoft.AspNetCore.Mvc;
using Web.Models;
using Web.DataAccess.Data;
using Web.DataAccess.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Web.Utility;

namespace WebForm_final.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Global.Role_user_admin)]
    public class BrandController : Controller
    {
        private readonly IUnitOfWork _UnitOfWork;
        public BrandController(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }
        public IActionResult Index()
        {
            List<Brand> objbrands = _UnitOfWork.Brand.GetAll().ToList();
            return View(objbrands);
        }

        //Edit method

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Brand? brandFromDb = _UnitOfWork.Brand.Get(c => c.id == id);
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
                _UnitOfWork.Brand.update(objbrand);
                _UnitOfWork.Brand.save();
                TempData["notification"] = "Edit brand successfully";
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
            if (ModelState.IsValid)
            {
                _UnitOfWork.Brand.add(objbrand);
                _UnitOfWork.Brand.save();
                TempData["notification"] = "Create brand successfully";
                return RedirectToAction("Index");
            }

            return View();
        }

        // Delete

        //public IActionResult Delete(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    Brand? brandFromDb = _UnitOfWork.Brand.Get(c => c.id == id);
        //    if (brandFromDb == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(brandFromDb);
        //}

        //[HttpPost]
        //public IActionResult Delete(Brand objbrand)
        //{
        //    _UnitOfWork.Brand.remove(objbrand);
        //    _UnitOfWork.Brand.save();
        //    TempData["notification"] = "Delete brand successfully";
        //    return RedirectToAction("index");
        //}
        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _UnitOfWork.Brand.GetAll() });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _UnitOfWork.Brand.Get(c => c.id == id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _UnitOfWork.Brand.remove(objFromDb);
            _UnitOfWork.Brand.save();
            return Json(new { success = true, message = "Delete successful" });
        }

        #endregion


    }
}
