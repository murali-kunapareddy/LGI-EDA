using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using WISSEN.EDA.Helpers;
using WISSEN.EDA.Models.Entities;
using WISSEN.EDA.Models.ViewModels;
using WISSEN.EDA.Repositories;

namespace EDA.Controllers
{
    public class SettingsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SettingsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }


        #region ========== COMPANIES ==========

        public IActionResult Companies()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetAllCompanies()
        {
            if (!ModelState.IsValid)
            {
                return Json("Invalid Model: " + ModelState);
            }
            return Json(await _unitOfWork.CompanyRepository.GetAllAsync());
        }

        [HttpPost]
        public async Task<JsonResult> AddCompany(Company model)
        {
            if (!ModelState.IsValid)
            {
                return Json("Invalid Model: " + ModelState);
            }

            var result = await _unitOfWork.CompanyRepository.AddAsync(model);
            if (result != "success")
                return Json($"Adding failed with {result}");
            else
            {
                await _unitOfWork.SaveAsync();
                return Json($"A new company {model.Name} at {model.City}, {model.CountryCode} is saved successfully.");
            }
        }

        [HttpGet]
        public async Task<JsonResult> EditCompany(int id)
        {
            if (!ModelState.IsValid)
            {
                return Json("Invalid Model: " + ModelState);
            }

            var model = await _unitOfWork.CompanyRepository.GetByIdAsync(id);
            return Json(model);
        }

        [HttpPost]
        public async Task<JsonResult> UpdateCompany(Company model)
        {
            if (!ModelState.IsValid)
            {
                return Json("Invalid Model: " + ModelState);
            }

            var ct = await _unitOfWork.CompanyRepository.GetByIdAsync(model.Code);
            ct.Name = model.Name;
            ct.AddressLine1 = model.AddressLine1;
            ct.AddressLine2 = model.AddressLine2;
            ct.City = model.City;
            ct.State = model.State;
            ct.CountryCode = model.CountryCode;
            ct.Zip = model.Zip;
            ct.Phone = model.Phone;
            ct.Fax = model.Fax;
            ct.Email = model.Email;
            ct.Logo = model.Logo;
            ct.ModifiedBy = "murali.kunapareddy@vendor.lgiglobal.com";  // logged in user
            ct.ModifiedOn = DateTime.Now;
            await _unitOfWork.CompanyRepository.UpdateAsync(ct);
            await _unitOfWork.SaveAsync();
            return Json($"A Company {model.Name} with <b>{model.Code}</b> is updated successfully.");
        }

        [HttpGet]
        public async Task<JsonResult> SuspendCompany(int id)
        {
            if (!ModelState.IsValid)
            {
                return Json("Invalid Model: " + ModelState);
            }

            var model = await _unitOfWork.CompanyRepository.GetByIdAsync(id);
            model.IsActive = !model.IsActive;
            model.ModifiedBy = "murali.kunapareddy@vendor.lgiglobal.com";  // logged in user
            model.ModifiedOn = DateTime.Now;
            var status = model.IsActive ? "REINSTATED" : "SUSPENDED";
            await _unitOfWork.SaveAsync();
            return Json($"A {model.Name} in <b>{model.City}, {model.CountryCode}</b> is {status} successfully.");
        }

        #endregion

        #region ========== COUNTRIES ==========

        public IActionResult Countries()
        {
            return View();
        }

        #endregion

        #region ========== USERS ==========

        [Authorize(Policy = "ViewUser")]
        public async Task<IActionResult> Users()
        {
            // show all the users
            var userList = await GetActiveUsers();
            return View(userList);
        }

        private async Task<List<UserListViewModel>> GetActiveUsers()
        {
            List<UserListViewModel> userList = new List<UserListViewModel>();
            var users = await _unitOfWork.UserRepository.GetAllAsync();
            foreach (var user in users)
            {
                if (!user.IsApproved || !user.IsActive || user.IsDeleted)
                {
                    continue; // Skip unapproved users
                }
                // get user profile from user id
                var userProfile = await _unitOfWork.UserProfileRepository.GetByIdAsync(user.Id);
                // get user role from user id
                var userRole = await _unitOfWork.UserRoleRepository.GetByUserIdAsync(user.Id);
                // pop UserListViewModel
                var userListViewModel = new UserListViewModel
                {
                    UserId = user.Id,
                    FirstName = userProfile?.FirstName,
                    LastName = userProfile?.LastName,
                    Gender = userProfile?.Gender,
                    Email = user.Email,
                    Designation = userProfile?.Designation,
                    Role = userRole?.RoleCode,
                    CompanyName = userProfile?.Company?.Name
                };
                userList.Add(userListViewModel);
            }
            return userList;
        }

        [HttpGet]
        public async Task<IActionResult> UserProfile(int? id)
        {
            ViewBag.Companies = await _unitOfWork.CommonRepository.GetAllCompaniesAsync();
            ViewBag.Countries = await _unitOfWork.CommonRepository.GetAllCountriesAsync();

            if (id == null)
            {
                var userVM = new UserViewModel();
                userVM.User = new User();
                userVM.UserProfile = new UserProfile();
                userVM.UserProfile.ProfilePhoto = "~/images/profiles/default.png";
                userVM.UserRole = new Role() { Code = "USER", Name = "User" };

                return View(new UserViewModel());
            }

            // get user profile from user id
            var userViewModel = new UserViewModel();

            // get user from id
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id.Value);
            if (user == null)
            {
                return NotFound();
            }
            userViewModel.UserId = user.Id;
            userViewModel.User = user;

            // get user profile from user id
            var userProfile = await _unitOfWork.UserProfileRepository.GetByIdAsync(user.Id);
            if (userProfile != null)
            {
                userViewModel.UserProfile = userProfile;
                if(userProfile.AddressId != 0)
                {
                    userViewModel.UserProfile.Address = await _unitOfWork.CommonRepository.GetAddressByIdAsync(userProfile.AddressId!.Value);
                }
                else
                {
                    userViewModel.UserProfile.Address = new Address();
                }
            }
            else
            {
                userViewModel.UserProfile = new UserProfile();
            }

            // get user role from user id
            var userRole = await _unitOfWork.UserRoleRepository.GetByUserIdAsync(user.Id);
            if (userRole != null)
            {
                userViewModel.UserRole = userRole.Role;
            }
            else
            {
                userViewModel.UserRole = new Role() { Code = "USER", Name = "User" };
            }

            return View(userViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SaveUserProfile(UserViewModel model)
        {
            //if (!ModelState.IsValid)
            //{
            //    ViewBag.Companies = await _unitOfWork.CommonRepository.GetAllCompaniesAsync();
            //    ViewBag.Countries = await _unitOfWork.CommonRepository.GetAllCountriesAsync();
            //    return View("UserProfile", model);
            //}

            if (model.UserId == 0)
            {
                try
                {
                    // Add new user
                    string salt;
                    string hashedPassword = PasswordHasher.HashPassword("Wissen@01", out salt);
                    model.User.FirstName = model.UserProfile.FirstName;
                    model.User.LastName = model.UserProfile.LastName;
                    model.User.PasswordHash = hashedPassword;
                    model.User.PasswordSalt = salt;
                    await _unitOfWork.UserRepository.AddAsync(model.User!);
                    int userId = model.User.Id;
                    // add user address
                    await _unitOfWork.CommonRepository.AddAddressAsync(model.UserProfile!.Address!);
                    // add user profile
                    await _unitOfWork.UserProfileRepository.AddAsync(model.UserProfile!);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error: {ex.Message}");
                    return View("UserProfile", model);
                }
            }
            else
            {
                // do not update user
                model.User.Id = model.UserId;
                // update or add address
                int addressId = 0;
                if (model.UserProfile.Address != null)
                {
                    await _unitOfWork.CommonRepository.UpdateAddressAsync(model.UserProfile.Address);
                    addressId = model.UserProfile.Address.Id;
                }
                else
                {
                    // add new address
                    await _unitOfWork.CommonRepository.AddAddressAsync(model.UserProfile.Address!);
                    addressId = model.UserProfile.Address.Id;
                }
                // update userprofile
                model.UserProfile.UserId = model.UserId;
                model.UserProfile.AddressId = addressId;
                await _unitOfWork.UserProfileRepository.UpdateAsync(model.UserProfile!);
            }

            await _unitOfWork.SaveAsync();
            return RedirectToAction("Users");
        }

        #endregion
    }
}
