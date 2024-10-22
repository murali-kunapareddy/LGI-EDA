using Microsoft.AspNetCore.Mvc;
using WISSEN.EDA.Models.Entities;
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
            ct.ModifiedBy = "murali.kunapareddy@bhjgroup.onmicrosoft.com";  // logged in user
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
            model.ModifiedBy = "murali.kunapareddy@bhjgroup.onmicrosoft.com";  // logged in user
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

        #region ========== PLANTS ==========

        public IActionResult PlantLocations()
        {
            return View();
        }

        #endregion

        #region ========== USERS ==========

        public IActionResult Users()
        {
            return View();
        }

        #endregion
    }
}
