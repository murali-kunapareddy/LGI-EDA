using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WISSEN.EDA.Models.Entities;
using WISSEN.EDA.Repositories;
using WISSEN.EDA.Repositories.Implementations;

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

        [HttpGet]
        public JsonResult GetMastersDDL()
        {
            if (!ModelState.IsValid)
            {
                return Json("Invalid Model: " + ModelState);
            }
            var masters = _unitOfWork.MasterRepository.GetDDLMasters();
            return Json(masters);
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
    }
}
