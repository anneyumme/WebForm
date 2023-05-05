using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web.DataAccess.Data;
using Web.DataAccess.Repository.Interface;
using Web.DataAccess.ViewModel;
using Web.Models;
using Web.Utility;

namespace WebForm_final.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Authorize(Roles = Global.Role_user_admin)]
	public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<UserApplication> _userManager;
        IUnitOfWork _unitOfWork { get; set; }
        public UserController(IUnitOfWork unitOfWork, ApplicationDbContext db, UserManager<UserApplication> userManager)
        {
			_unitOfWork = unitOfWork;
            _db = db;
            _userManager = userManager;
            
        }
		public IActionResult Index()
		{
			return View();
		}

        public IActionResult Edit(string? userid)
        {
            UserApplication obj = _unitOfWork.userApplication.Get(u => u.Id == userid);
            string RoleId = _db.UserRoles.FirstOrDefault(u => u.UserId == userid).RoleId; // find role id of current user 
            RoleMannagementViewModel RoleVM = new RoleMannagementViewModel()
            {
                UserApplication = obj,
                RoleList = _db.Roles.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Name
				}),
            };
            RoleVM.UserApplication.Role = _db.Roles.FirstOrDefault(u => u.Id == RoleId).Name;
            
            return View(RoleVM);
        }
        [HttpPost]
        public IActionResult Edit(RoleMannagementViewModel RoleManagamentVM)
        {
            string Roleid = _db.UserRoles.FirstOrDefault(u => u.UserId == RoleManagamentVM.UserApplication.Id).RoleId;
            string oldRole = _db.Roles.FirstOrDefault(u => u.Id == Roleid).Name;
			var obj = _unitOfWork.userApplication.Get(u => u.Id == RoleManagamentVM.UserApplication.Id);
			if (!(RoleManagamentVM.UserApplication.Role ==  oldRole))
            {
                _userManager.RemoveFromRoleAsync(obj, oldRole).GetAwaiter().GetResult();
				_userManager.AddToRoleAsync(obj, RoleManagamentVM.UserApplication.Role).GetAwaiter().GetResult();

			}
			_db.SaveChanges();
			TempData["notification"] = "Edit user successfully";
			return RedirectToAction(nameof(Index));
        }

		#region API Calls
		[HttpGet]
        public IActionResult GetAll()
        {
            List<UserApplication> obj = _unitOfWork.userApplication.GetAll().ToList();
             var userRole = _db.UserRoles.ToList(); // List user with role
            var roles = _db.Roles.ToList(); // List all role name
            // Logic: inside UserApplication have userId, we will map to userRoleTable to find Roleid 
            // of this user by using userId, from RoleId we will find the name of role inside RolesTable
            foreach (var UserApplication  in obj)
            {
                var RoleId = userRole.FirstOrDefault(u => u.UserId == UserApplication.Id).RoleId;
				UserApplication.Role = roles.FirstOrDefault(u => u.Id == RoleId).Name;

			}

			return Json(new { data = obj});
		}
        [HttpDelete]
        public IActionResult LockUnlock(string? id) 
        {
           var userFromDb = _db.UserApplications.FirstOrDefault(u=> u.Id == id);
            if (userFromDb == null)
            {
				return Json(new { success = false});
			}
            if(userFromDb.LockoutEnd !=null && userFromDb.LockoutEnd >  DateTime.Now)
            {
                // User currently lock now we need to unlock.
                userFromDb.LockoutEnd = DateTime.Now;
            }
            else
            {
                userFromDb.LockoutEnd = DateTime.Now.AddYears(10);
            }
            _db.SaveChanges();

			return Json(new { success = true });
		}
		#endregion
	}
}
