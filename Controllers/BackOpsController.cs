using Microsoft.AspNetCore.Mvc;
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

        public IActionResult MasterOps()
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

        public JsonResult GetMastersForDDL()
        {
            if (!ModelState.IsValid)
            {
                return Json("Invalid Model: " + ModelState);
            }

            //var ddlMasters = 
            return Json("");
        }
    }
}
