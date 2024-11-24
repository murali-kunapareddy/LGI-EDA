using Microsoft.AspNetCore.Mvc;
using WISSEN.EDA.Models.Entities;
using WISSEN.EDA.Repositories;

namespace WISSEN.EDA.Controllers
{
    public class BackOpsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BackOpsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

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
