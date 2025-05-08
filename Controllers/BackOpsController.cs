using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using WISSEN.EDA.Helpers;
using WISSEN.EDA.Models.Entities;
using WISSEN.EDA.Models.ViewModels;
using WISSEN.EDA.Repositories;
using WISSEN.EDA.Services;

namespace WISSEN.EDA.Controllers
{
    public class BackOpsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomAuthenticationService _authService;
        private readonly IConfiguration _configuration;

        public BackOpsController(IUnitOfWork unitOfWork, ICustomAuthenticationService authService, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _authService = authService;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region ======= Authentication ======

        // Login Action
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _unitOfWork.UserRepository.GetByEmailAsync(model.Email!);
            if (user?.IsApproved == false)
            {
                // Redirect to NotApproved view
                return RedirectToAction("NotApproved", "CommCenter");
            }

            var principal = await _authService.AuthenticateUser(model.Email!, model.Password!);
            if (principal != null)
            {
                await _authService.SignIn(HttpContext, principal);
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Invalid login attempt.");
            return View(model);
        }


        // Logout Action
        public async Task<IActionResult> Logout()
        {
            await _authService.SignOut(HttpContext);
            return RedirectToAction("Login"); // Redirect to login page
        }

        // Register Action
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var existingUser = await _unitOfWork.UserRepository.GetByEmailAsync(model.Email);
            if (existingUser != null)
            {
                ModelState.AddModelError("Email", "Email already exists");
                return View(model);
            }

            string salt;
            string hashedPassword = PasswordHasher.HashPassword(model.Password, out salt);

            var user = new User
            {
                Email = model.Email,
                PasswordHash = hashedPassword,
                PasswordSalt = salt,
                FirstName = model.FirstName,
                LastName = model.LastName,
                IsApproved = false // Default to not approved
            };

            await _unitOfWork.UserRepository.AddAsync(user);
            await _unitOfWork.SaveAsync();

            TempData["Message"] = "Registration successful. Please wait for admin approval.";
            return RedirectToAction("Login");
        }

        // Approve action - Requires Authorization
        [HttpGet]
        [Authorize(Policy = "ApproveUser")]
        public async Task<IActionResult> ApproveUsers()
        {
            var unapprovedUsers = await _unitOfWork.UserRepository.GetAllAsync();
            return View(unapprovedUsers.Where(u => !u.IsApproved));
        }

        [HttpPost]
        [Authorize(Policy = "ApproveUser")]
        public async Task<IActionResult> ApproveUser(int id)
        {
            // 1. Fetch the user by ID
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            // 2. Mark the user as approved
            user.IsApproved = true;
            await _unitOfWork.UserRepository.UpdateAsync(user);

            // 3. Assign the "USER" role
            var userRole = new UserRole
            {
                UserId = user.Id,
                RoleCode = "USER", // Default role
                IsActive = true,
                CreatedBy = "SYSTEM", // Replace with logged-in admin's email if available
                CreatedOn = DateTime.Now
            };
            await _unitOfWork.UserRoleRepository.AddAsync(userRole);

            // 4. Create a new UserProfile entry
            var userProfile = new UserProfile
            {
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Gender = "O", // defaults to other
                CreatedBy = "SYSTEM", // Replace with logged-in admin's email if available
                CreatedOn = DateTime.Now
            };
            await _unitOfWork.UserProfileRepository.AddAsync(userProfile);

            // Save all changes
            await _unitOfWork.SaveAsync();

            return RedirectToAction("ApproveUsers");
        }

        #endregion

        #region ====== Dashboard ======


        #endregion

        #region ====== Users ======

        

        // List Users - Requires Authorization
        [HttpGet]
        [Authorize(Policy = "ViewUser")]
        public async Task<JsonResult> GetAllUsers()
        {
            if (!ModelState.IsValid)
            {
                return Json("Invalid Model: " + ModelState);
            }

            return Json(await _unitOfWork.UserRepository.GetAllAsync());
        }

        // View User Details
        [HttpGet]
        [Authorize(Policy = "ViewUser")]
        public async Task<JsonResult> GetUserProfile(string email)
        {
            if (!ModelState.IsValid)
            {
                return Json("Invalid Model: " + ModelState);
            }
            // get user
            var user = await _unitOfWork.UserRepository.GetByEmailAsync(email);
            if (user == null)
            {
                return Json("User not found");
            }
            // get profile from user id
            var userProfile = await _unitOfWork.UserProfileRepository.GetByIdAsync(user.Id);
            // pop UserViewModel
            var userViewModel = new UserViewModel()
            {
                User = user,
                UserProfile = userProfile
            };
            return Json(userViewModel);
        }

        // Edit User Details - Requires Authorization
        [HttpGet]
        [Authorize(Policy = "EditUser")]
        public IActionResult Edit(string email)
        {
            var user = _unitOfWork.UserRepository.GetByEmailAsync(email); // Use UoW and repo
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        public async Task<JsonResult> GetUserDetails(string email)
        {
            if (!ModelState.IsValid)
            {
                return Json("Invalid Model: " + ModelState);
            }
            var user = await _unitOfWork.UserRepository.GetByEmailAsync(email); // Use UoW and repo
            return Json(user);
        }

        [HttpPost]
        [Authorize(Policy = "EditUser")]
        public async Task<IActionResult> Edit(string email, User model)
        {
            if (ModelState.IsValid)
            {
                var user = await _unitOfWork.UserRepository.GetByEmailAsync(email); // Use UoW and repo
                if (user == null)
                {
                    return NotFound();
                }
                //update the user object.
                await _unitOfWork.UserRepository.UpdateAsync(user);
                await _unitOfWork.SaveAsync();
                return RedirectToAction("List");
            }
            return View(model);
        }

        // Create User - Requires Authorization
        [HttpGet]
        [Authorize(Policy = "CreateUser")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "CreateUser")]
        public async Task<IActionResult> Create(User model, string password)
        {
            if (ModelState.IsValid)
            {
                //check if the user already exists.
                var existingUser = await _unitOfWork.UserRepository.GetByEmailAsync(model.Email!);
                if (existingUser != null)
                {
                    ModelState.AddModelError("Email", "Email already exists");
                    return View(model);
                }

                string salt;
                string hashedPassword = PasswordHasher.HashPassword(password, out salt);

                var user = new User
                {
                    Email = model.Email,
                    PasswordHash = hashedPassword,
                    PasswordSalt = salt,
                };

                await _unitOfWork.UserRepository.AddAsync(user);
                await _unitOfWork.SaveAsync();
                return RedirectToAction("List");
            }
            return View(model);
        }

        // Delete User - Requires Authorization
        [HttpGet]
        [Authorize(Policy = "DeleteUser")]
        public async Task<IActionResult> Delete(string email)
        {
            var user = await _unitOfWork.UserRepository.GetByEmailAsync(email); // Use UoW
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        [Authorize(Policy = "DeleteUser")]
        public async Task<IActionResult> DeleteConfirmed(string email)
        {
            var user = _unitOfWork.UserRepository.GetByEmailAsync(email); // Use UoW
            if (user == null)
            {
                return NotFound();
            }
            await _unitOfWork.UserRepository.DeleteAsync(email);  // Use UoW and repo
            await _unitOfWork.SaveAsync();
            return RedirectToAction("List");
        }

        #endregion

        #region ====== Masters ======

        public IActionResult Masters()
        {
            return View();
        }

        public async Task<JsonResult> GetAllMasterItems()
        {
            if (!ModelState.IsValid)
            {
                return Json("Invalid Model: " + ModelState);
            }
            return Json(await _unitOfWork.MasterRepository.GetAllAsync());
        }

        [HttpPost]
        public async Task<JsonResult> AddMasterItem(MasterItem model)
        {
            if (!ModelState.IsValid)
            {
                return Json("Invalid Model: " + ModelState);
            }

            await _unitOfWork.MasterRepository.AddAsync(model);
            await _unitOfWork.SaveAsync();
            return Json($"A new {model.Name} with {model.Key} is saved successfully.");
        }

        [HttpGet]
        public async Task<JsonResult> EditMasterItem(int id)
        {
            if (!ModelState.IsValid)
            {
                return Json("Invalid Model: " + ModelState);
            }

            var model = await _unitOfWork.MasterRepository.GetByIdAsync(id);
            return Json(model);
        }

        [HttpPost]
        public async Task<JsonResult> UpdateMasterItem(MasterItem model)
        {
            if (!ModelState.IsValid)
            {
                return Json("Invalid Model: " + ModelState);
            }

            var ct = await _unitOfWork.MasterRepository.GetByIdAsync(model.Id);
            ct.Name = model.Name;
            ct.Key = model.Key;
            ct.Value = model.Value;
            ct.Sequence = model.Sequence;
            ct.Notes = model.Notes;
            ct.ModifiedBy = "murali.kunapareddy@vendor.lgiglobal.com";  // logged in user
            ct.ModifiedOn = DateTime.Now;
            await _unitOfWork.MasterRepository.UpdateAsync(ct);
            await _unitOfWork.SaveAsync();
            return Json($"A {model.Name} with <b>{model.Key}</b> is updated successfully.");
        }

        [HttpGet]
        public async Task<JsonResult> SuspendMasterItem(int id)
        {
            if (!ModelState.IsValid)
            {
                return Json("Invalid Model: " + ModelState);
            }

            var model = await _unitOfWork.MasterRepository.GetByIdAsync(id);
            model.IsActive = !model.IsActive;
            model.ModifiedBy = "murali.kunapareddy@vendor.lgiglobal.com";  // logged in user
            model.ModifiedOn = DateTime.Now;
            var status = model.IsActive ? "REINSTATED" : "SUSPENDED";
            await _unitOfWork.SaveAsync();
            return Json($"A {model.Name} with <b>{model.Key}</b> is {status} successfully.");
        }

        [HttpGet]
        public async Task<JsonResult> DeleteMasterItem(int id)
        {
            if (!ModelState.IsValid)
            {
                return Json("Invalid Model: " + ModelState);
            }

            var model = await _unitOfWork.MasterRepository.GetByIdAsync(id);
            model.IsDeleted = !model.IsDeleted;
            model.ModifiedBy = "murali.kunapareddy@vendor.lgiglobal.com";  // logged in user
            model.ModifiedOn = DateTime.Now;
            var status = model.IsDeleted ? "DELETED" : "REINSTERED";
            await _unitOfWork.SaveAsync();
            return Json($"A {model.Name} with <b>{model.Key}</b> is {status} successfully.");
        }

        #endregion

        #region ====== commons ======

        [HttpGet]
        public JsonResult GetMastersDDL()
        {
            if (!ModelState.IsValid)
            {
                return Json("Invalid Model: " + ModelState);
            }
            var masters = _unitOfWork.CommonRepository.GetDDLMasters();
            return Json(masters);
        }

        [HttpGet]
        public JsonResult GetCountriesDDL()
        {
            if (!ModelState.IsValid)
            {
                return Json("Invalid Model: " + ModelState);
            }
            var countries = _unitOfWork.CommonRepository.GetDDLCountries();
            return Json(countries);
        }

        [HttpGet]
        public JsonResult GetCompaniesDDL()
        {
            if (!ModelState.IsValid)
            {
                return Json("Invalid Model: " + ModelState);
            }
            var companies = _unitOfWork.CommonRepository.GetDDLCompanies();
            return Json(companies);
        }

        [HttpGet]
        public JsonResult GetSelectedMasterDDL(string masterName)
        {
            if (!ModelState.IsValid)
            {
                return Json("Invalid Model: " + ModelState);
            }
            var masters = _unitOfWork.CommonRepository.GetDDLSelectedMasters(masterName);
            return Json(masters);
        }

        #endregion
    }
}
