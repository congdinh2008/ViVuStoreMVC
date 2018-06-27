using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ViVuStoreMVC.Auth;
using ViVuStoreMVC.ViewModels;

namespace ViVuStoreMVC.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UserManagement()
        {
            var users = _userManager.Users;

            return View(users);
        }

        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserViewModel addUserViewModel)
        {
            if (!ModelState.IsValid) return View(addUserViewModel);

            var user = new ApplicationUser()
            {
                Name = addUserViewModel.Name,
                Sex = addUserViewModel.Sex,
                DateOfBirth = addUserViewModel.DateOfBirth,
                City = addUserViewModel.City,
                Address = addUserViewModel.Address,
                UserName = addUserViewModel.Email,
                Email = addUserViewModel.Email
            };

            IdentityResult result = await _userManager.CreateAsync(user, addUserViewModel.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("UserManagement", _userManager.Users);
            }

            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(addUserViewModel);
        }

        public async Task<IActionResult> EditUser(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null)
                return RedirectToAction("UserManagement", _userManager.Users);

            var editUserViewModel = new EditUserViewModel()
            {
                Id = user.Id,
                Name = user.Name,
                Sex = user.Sex,
                DateOfBirth = user.DateOfBirth,
                City = user.City,
                Address = user.Address,
                Email = user.Email
            };

            return View(editUserViewModel);

        }

        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserViewModel editUserViewModel)
        {
            var user = await _userManager.FindByIdAsync(editUserViewModel.Id.ToString());

            if (user != null)
            {
                user.Name = editUserViewModel.Name;
                user.Sex = editUserViewModel.Sex;
                user.Email = editUserViewModel.Email;
                user.DateOfBirth = editUserViewModel.DateOfBirth;
                user.City = editUserViewModel.City;
                user.Address = editUserViewModel.Address;

                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                    return RedirectToAction("UserManagement", _userManager.Users);

                ModelState.AddModelError("", "Xảy ra lỗi khi cập nhật tài khoản, vui lòng thử lại.");

                return View(editUserViewModel);
            }

            return RedirectToAction("UserManagement", _userManager.Users);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(Guid Id)
        {
            var user = await _userManager.FindByIdAsync(Id.ToString());

            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                    return RedirectToAction("UserManagement");
                else
                    ModelState.AddModelError("", "Xảy ra lỗi khi xóa tài khoản, vui lòng thử lại.");
            }
            else
            {
                ModelState.AddModelError("", "Tài khoản không tồn tại!");
            }
            return View("UserManagement", _userManager.Users);
        }
    }
}
