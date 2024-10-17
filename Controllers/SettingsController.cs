using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Countries()
        {
            return View();
        }

        public IActionResult PlantLocations()
        {
            return View();
        }

        public IActionResult Users()
        {
            return View();
        }
    }
}
