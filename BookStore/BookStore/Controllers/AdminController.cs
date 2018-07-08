using BookStore.Auth;
using BookStore.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public AdminController(UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region UserManager

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
            if (!ModelState.IsValid)
            {
                return View(addUserViewModel);
            }

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
                return RedirectToAction("UserManagement", _userManager.Users);

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

            var claims = await _userManager.GetClaimsAsync(user);

            var editUserViewModel = new EditUserViewModel()
            {
                Id = user.Id,
                Name = user.Name,
                Sex = user.Sex,
                DateOfBirth = user.DateOfBirth,
                City = user.City,
                Address = user.Address,
                Email = user.Email,
                UserClaims = claims.Select(c => c.Value).ToList()
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
                {
                    return RedirectToAction("UserManagement");
                }
                else
                {
                    ModelState.AddModelError("", "Xảy ra lỗi khi xóa tài khoản, vui lòng thử lại.");
                }
            }
            else
            {
                ModelState.AddModelError("", "Tài khoản không tồn tại!");
            }
            return View("UserManagement", _userManager.Users);
        }
        #endregion

        #region RoleManager

        public IActionResult RoleManagement()
        {
            var roles = _roleManager.Roles;
            return View(roles);
        }

        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(
            AddRoleViewModel addRoleViewModel)
        {
            if (!ModelState.IsValid)
                return View(addRoleViewModel);

            var role = new ApplicationRole
            {
                Name = addRoleViewModel.Name
            };

            IdentityResult result = await _roleManager.CreateAsync(role);

            if (result.Succeeded)
                return RedirectToAction("RoleManagement", _roleManager.Roles);

            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(addRoleViewModel);
        }

        public async Task<IActionResult> EditRole(Guid id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());

            if (role == null)
                return RedirectToAction("RoleManagement", _roleManager.Roles);

            var editRoleViewModel = new EditRoleViewModel()
            {
                Id = role.Id,
                Name = role.Name,
                Users = new List<string>()
            };

            foreach (var user in _userManager.Users)
            {
                if (await _userManager.IsInRoleAsync(user, role.Name))
                    editRoleViewModel.Users.Add(user.UserName);
            }

            return View(editRoleViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel editRoleViewModel)
        {
            var role = await _roleManager.FindByIdAsync(editRoleViewModel.Id.ToString());

            if (role != null)
            {
                role.Name = editRoleViewModel.Name;

                var result = await _roleManager.UpdateAsync(role);

                if (result.Succeeded)
                    return RedirectToAction("RoleManagement", _roleManager.Roles);

                ModelState.AddModelError("", "Role not updated, something went wrong.");

                return View(editRoleViewModel);
            }

            return RedirectToAction("RoleManagement", _roleManager.Roles);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteRole(Guid id)
        {
            ApplicationRole role = await _roleManager.FindByIdAsync(id.ToString());
            if (role != null)
            {
                var result = await _roleManager.DeleteAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("RoleManagement", _roleManager.Roles);
                }

                ModelState.AddModelError("", "Something went wrong while deleting this role.");
            }
            else
            {
                ModelState.AddModelError("", "This role can't be found.");
            }
            return View("RoleManagement", _roleManager.Roles);
        }

        //Users in roles

        public async Task<IActionResult> AddUserToRole(Guid roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId.ToString());

            if (role == null)
            {
                return RedirectToAction("RoleManagement", _roleManager.Roles);
            }

            var addUserToRoleViewModel = new UserRoleViewModel { RoleId = role.Id };

            foreach (var user in _userManager.Users)
            {
                if (!await _userManager.IsInRoleAsync(user, role.Name))
                {
                    addUserToRoleViewModel.Users.Add(user);
                }
            }

            return View(addUserToRoleViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddUserToRole(UserRoleViewModel userRoleViewModel)
        {
            var user = await _userManager.FindByIdAsync(userRoleViewModel.UserId.ToString());
            var role = await _roleManager.FindByIdAsync(userRoleViewModel.RoleId.ToString());

            var result = await _userManager.AddToRoleAsync(user, role.Name);

            if (result.Succeeded)
                return RedirectToAction("RoleManagement", _roleManager.Roles);

            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(userRoleViewModel);
        }

        public async Task<IActionResult> DeleteUserFromRole(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);

            if (role == null)
                return RedirectToAction("RoleManagement", _roleManager.Roles);

            var addUserToRoleViewModel = new UserRoleViewModel { RoleId = role.Id };

            foreach (var user in _userManager.Users)
            {
                if (await _userManager.IsInRoleAsync(user, role.Name))
                    addUserToRoleViewModel.Users.Add(user);
            }

            return View(addUserToRoleViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUserFromRole(UserRoleViewModel userRoleViewModel)
        {
            var user = await _userManager.FindByIdAsync(userRoleViewModel.UserId.ToString());
            var role = await _roleManager.FindByIdAsync(userRoleViewModel.RoleId.ToString());

            var result = await _userManager.RemoveFromRoleAsync(user, role.Name);

            if (result.Succeeded)
                return RedirectToAction("RoleManagement", _roleManager.Roles);

            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(userRoleViewModel);
        }

        #endregion

        #region Claims

        public async Task<IActionResult> ManageClaimsForUser(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user == null)
                return RedirectToAction("UserManagement", _userManager.Users);

            var claimsManagementViewModel =
                new ClaimsManagementViewModel
                {
                    UserId = user.Id.ToString(),
                    AllClaimsList = BookStoreClaimTypes.ClaimsList
                };

            return View(claimsManagementViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ManageClaimsForUser(ClaimsManagementViewModel claimsManagementViewModel)
        {
            var user = await _userManager.FindByIdAsync(claimsManagementViewModel.UserId.ToString());

            if (user == null)
                return RedirectToAction("UserManagement", _userManager.Users);

            IdentityUserClaim<Guid> claim =
                new IdentityUserClaim<Guid>
                {
                    UserId = user.Id,
                    ClaimType = claimsManagementViewModel.ClaimId,
                    ClaimValue = claimsManagementViewModel.ClaimId
                };

            user.Claims.Add(claim);
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
                return RedirectToAction("UserManagement", _userManager.Users);

            ModelState.AddModelError("", "Tài khoản cập nhật lỗi.");

            return View(claimsManagementViewModel);
        }

        #endregion
    }
}
