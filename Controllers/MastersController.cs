using Microsoft.AspNetCore.Mvc;
using WISSEN.EDA.Models.Entities;
using WISSEN.EDA.Repositories;

namespace EDA.Controllers
{
    public class MastersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public MastersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region ***** ConsigneeTypes *****

        public IActionResult ConsigneeTypes()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetAllConsigneeTypes()
        {
            if (!ModelState.IsValid)
            {
                return Json("Invalid Model: " + ModelState);
            }
            return Json(await _unitOfWork.MasterRepository.GetAllAsync("CONSIGNEETYPE"));
        }

        [HttpPost]
        public async Task<JsonResult> AddConsigneeType(MasterItem model)
        {
            if (!ModelState.IsValid)
            {
                return Json("Invalid Model: " + ModelState);
            }

            await _unitOfWork.MasterRepository.AddAsync(model);
            await _unitOfWork.SaveAsync();
            return Json("Consignee Type " + model.Key + " saved successfully.");
        }

        [HttpGet]
        public async Task<JsonResult> EditConsigneeType(int id)
        {
            if (!ModelState.IsValid)
            {
                return Json("Invalid Model: " + ModelState);
            }

            var model = await _unitOfWork.MasterRepository.GetByIdAsync(id);
            return Json(model);
        }

        [HttpGet]
        public async Task<JsonResult> SuspendConsigneeType(int id)
        {
            if (!ModelState.IsValid)
            {
                return Json("Invalid Model: " + ModelState);
            }

            var model = await _unitOfWork.MasterRepository.GetByIdAsync(id);
            model.IsActive = !model.IsActive;
            model.ModifiedBy = "murali.kunapareddy@bhjgroup.onmicrosoft.com";  // logged in user
            model.ModifiedOn = DateTime.Now;
            await _unitOfWork.SaveAsync();
            return Json("Consignee Type <b>" + model.Key + "</b> suspended successfully.");
        }

        [HttpPost]
        public async Task<JsonResult> UpdateConsigneeType(MasterItem model)
        {
            if (!ModelState.IsValid)
            {
                return Json("Invalid Model: " + ModelState);
            }

            var ct = await _unitOfWork.MasterRepository.GetByIdAsync(model.Id);
            ct.Key = model.Key;
            ct.Value = model.Value;
            ct.Sequence = model.Sequence;
            ct.Notes = model.Notes;
            ct.ModifiedBy = "murali.kunapareddy@bhjgroup.onmicrosoft.com";  // logged in user
            ct.ModifiedOn = DateTime.Now;
            await _unitOfWork.MasterRepository.UpdateAsync(ct);
            await _unitOfWork.SaveAsync();
            return Json("Consignee Type " + model.Key + " updated successfully.");
        }

        #endregion

        #region ***** ContainerSizes *****
        public IActionResult ContainerSizes()
        {
            return View();
        }
        #endregion

        #region ***** Incoterms *****
        public async Task<IActionResult> Incoterms()
        {
            var incoterms = await _unitOfWork.MasterRepository.GetAllAsync("INCOTERM");
            return View(incoterms);
        }

        [HttpPost]
        public IActionResult AddIncoterms(MasterItem model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            return View();
        }
        #endregion

        #region ***** PaperworksList *****
        public IActionResult PaperworksList()
        {
            return View();
        }
        #endregion

        #region ***** PaymentTerms *****
        public IActionResult PaymentTerms()
        {
            return View();
        }
        #endregion

        #region ***** Ports *****
        public IActionResult Ports()
        {
            return View();
        }
        #endregion

        #region ***** Products *****
        public IActionResult Products()
        {
            return View();
        }
        #endregion

        #region ***** ShipVia *****
        public IActionResult ShipVia()
        {
            return View();
        }
        #endregion
    }
}
