using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.AccessControl;
using Web.DataAccess.Repository.Interface;
using Web.DataAccess.ViewModel;
using Web.Models;

namespace WebForm_final.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ProductController : Controller
	{
		private readonly IUnitOfWork _UnitOfWork;
		private readonly IWebHostEnvironment _WebHostEnvironment;
		public ProductController(IUnitOfWork UnitOfWork, IWebHostEnvironment webHostEnvironment)
		{
			_UnitOfWork = UnitOfWork;
			_WebHostEnvironment = webHostEnvironment;
		}
		public IActionResult Index()
		{
			List<Product> objproduct = _UnitOfWork.Product.GetAll(includeProperties: "brand").ToList();
			return View(objproduct);
		}

		//Edit method

		public IActionResult Edit(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			Product? brandFromDb = _UnitOfWork.Product.Get(c => c.id == id);
			if (brandFromDb == null)
			{

				return NotFound();
			}
			IEnumerable<SelectListItem> brandList = _UnitOfWork.Brand.GetAll().Select(i => new SelectListItem
			{
				Text = i.name,
				Value = i.id.ToString()   //Select() method to transform each brand object into a new SelectListItem object
			});

			ProductViewModel productVM = new ProductViewModel();
			productVM.BrandList = brandList;
			productVM.Product = brandFromDb;
			return View(productVM);
		}
		[HttpPost]
		public IActionResult Edit(ProductViewModel productVM, IFormFile? file)
		{
			if (ModelState.IsValid)
			{
				string RootPath = _WebHostEnvironment.WebRootPath;
				if (file != null)
				{
					string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
					string imagePath = Path.Combine(RootPath, @"Images/Product");
					if (!string.IsNullOrEmpty(productVM.Product.imageUrl))
					{
						string imagePathOld = Path.Combine(RootPath, productVM.Product.imageUrl.TrimStart('\\'));
						if (System.IO.File.Exists(imagePathOld))
						{
							System.IO.File.Delete(imagePathOld);
						}
						using (var fileStream = new FileStream(Path.Combine(imagePath, fileName), FileMode.Create))
						{
							file.CopyTo(fileStream);
						}
						productVM.Product.imageUrl = @"\Images\Product\" + fileName;
					}
				}
				_UnitOfWork.Product.update(productVM.Product);
				_UnitOfWork.Product.save();
				TempData["notification"] = "Edit brand successfully";
				return RedirectToAction("Index");
			}
			return View();
		}

		// Create method

		public IActionResult Create()
		{
			IEnumerable<SelectListItem> brandList = _UnitOfWork.Brand.GetAll().Select(i => new SelectListItem
			{
				Text = i.name,
				Value = i.id.ToString()   //Select() method to transform each brand object into a new SelectListItem object
			});
			//ViewBag.BrandList = brandList;
			ProductViewModel productVM = new ProductViewModel();
			productVM.BrandList = brandList;
			productVM.Product = new Product();

			return View(productVM);
		}

		[HttpPost]
		public IActionResult Create(ProductViewModel productVM, IFormFile? file)
		{
			//if(objbrand.name == null )
			//{
			//    ModelState.AddModelError("name", "Brand Name is required");
			//    return View();
			//}
			// Create a ViewBag property called "BrandList" and set its value from the "brandList" object
			if (ModelState.IsValid)
			{

				string RootPath = _WebHostEnvironment.WebRootPath;
				if (file != null)
				{
					string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
					string imagePath = Path.Combine(RootPath, @"Images/Product");
					using (var filestream = new FileStream(Path.Combine(imagePath, fileName), FileMode.Create))
					{
						file.CopyTo(filestream);
					}
					productVM.Product.imageUrl = @"Images/Product/" + fileName;
				}

				_UnitOfWork.Product.add(productVM.Product);
				_UnitOfWork.Product.save();
				TempData["notification"] = "Create brand successfully";
				return RedirectToAction("Index");
			}
			else
			{
				IEnumerable<SelectListItem> brandList = _UnitOfWork.Brand.GetAll().Select(i => new SelectListItem
				{
					Text = i.name,
					Value = i.id.ToString()   //Select() method to transform each brand object into a new SelectListItem object
				});
				productVM.BrandList = brandList;
				return View(productVM);
			}

		}

		// Delete

		//public IActionResult Delete(int? id)
		//{
		//	if (id == null || id == 0)
		//	{
		//		return NotFound();
		//	}
		//	Product? brandFromDb = _UnitOfWork.Product.Get(c => c.id == id);
		//	if (brandFromDb == null)
		//	{
		//		return NotFound();
		//	}
		//	return View(brandFromDb);
		//}

		//[HttpPost]
		//public IActionResult Delete(Product objbrand)
		//{	
		//	_UnitOfWork.Product.remove(objbrand);
		//	_UnitOfWork.Product.save();
		//	TempData["notification"] = "Delete brand successfully";
		//	return RedirectToAction("index");
		//}

		#region API CALLS
		[HttpGet]
		public IActionResult GetAll()
		{
			var allObj = _UnitOfWork.Product.GetAll(includeProperties: "brand").ToList();
			return Json(new { data = allObj });
		}

		[HttpDelete]
		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			Product? ProductFromDb = _UnitOfWork.Product.Get(c => c.id == id);
			if (ProductFromDb == null)
			{
				return NotFound();
			}

			if (!string.IsNullOrEmpty(ProductFromDb.imageUrl))
			{
				string imagePathOld = Path.Combine(_WebHostEnvironment.WebRootPath, ProductFromDb.imageUrl.TrimStart('\\'));
				if (System.IO.File.Exists(imagePathOld))
				{
					System.IO.File.Delete(imagePathOld);
				}
				_UnitOfWork.Product.remove(ProductFromDb);
				_UnitOfWork.Product.save();
			}

			return Json(new {success= true,  message= "Delete Successfuly"});

			#endregion
		}
	}
}
