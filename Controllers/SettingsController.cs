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

            var userVM = new UserViewModel();
            // check if id is null
            if (id == null)
            {   
                userVM.User = new User();
                userVM.UserProfile = new UserProfile();
                userVM.UserProfile.ProfilePhoto = "~/images/profiles/default.png";
                userVM.UserRole = new Role() { Code = "USER", Name = "User" };

                return View(new UserViewModel());
            }
            // get user from id
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id.Value);
            if (user == null)
            {
                return NotFound();
            }
            userVM.UserId = user.Id;
            userVM.User = user;
            // get user role from user id
            var userRole = await _unitOfWork.UserRoleRepository.GetByUserIdAsync(user.Id);
            if (userRole != null)
            {
                userVM.UserRole = await _unitOfWork.RoleRepository.GetByCodeAsync(string.IsNullOrEmpty(userRole.RoleCode) ? "USER" : userRole.RoleCode);
            }
            else
            {
                userVM.UserRole = new Role() { Code = "USER", Name = "User" };
            }
            
            // get user profile from user id
            var userProfile = await _unitOfWork.UserProfileRepository.GetByIdAsync(user.Id);
            if (userProfile != null)
            {
                userVM.UserProfile = userProfile;
                if(userProfile.AddressId != 0)
                {
                    userVM.UserProfile.Address = await _unitOfWork.CommonRepository.GetAddressByIdAsync(userProfile.AddressId!.Value);
                }
                else
                {
                    userVM.UserProfile.Address = new Address();
                }
            }
            else
            {
                userVM.UserProfile = new UserProfile();
            }

            return View(userVM);
        }

        [HttpPost]
        public async Task<IActionResult> SaveUserProfile(UserViewModel model)
        {
            /*
             * 1. check for user id
             * 2. if user id is 0, add new user
             *  a. add new user
             *  b. add new address for the user
             *  c. add new user profile
             *  d. add user role
             *  e. add user profile photo
             * 3. if user id is not 0, update user
             *  a. update user (firstname, lastname)
             *  b. update address
             *  c. update user profile
             *  d. update user role
             *  e. update user profile photo
            */

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
                // get address from user id
                var userProfile = await _unitOfWork.UserProfileRepository.GetByIdAsync(model.UserId);
                if (userProfile.AddressId != null && userProfile.AddressId != 0)
                {
                    // update address from model's address
                    var address = await _unitOfWork.CommonRepository.GetAddressByIdAsync(userProfile.AddressId.Value);

                    addressId = userProfile.AddressId.Value;
                    address.AddressLine = model.UserProfile?.Address?.AddressLine;
                    address.City = model.UserProfile?.Address?.City;
                    address.State = model.UserProfile?.Address?.State;
                    address.CountryCode = model.UserProfile?.Address?.CountryCode;
                    address.Zip = model.UserProfile.Address.Zip;
                    address.ModifiedBy = "Logged in User";
                    address.ModifiedOn = DateTime.Now;

                    await _unitOfWork.CommonRepository.UpdateAddressAsync(model.UserProfile.Address);
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
