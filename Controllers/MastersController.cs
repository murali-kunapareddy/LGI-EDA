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

        #region ========== ConsigneeTypes ==========

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
            model.ModifiedBy = "murali.kunapareddy@vendor.lgiglobal.com";  // logged in user
            model.ModifiedOn = DateTime.Now;
            await _unitOfWork.SaveAsync();
            if (model.IsActive)
                return Json("Consignee Type <b>" + model.Key + "</b> reinstated successfully.");
            else
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
            ct.ModifiedBy = "murali.kunapareddy@vendor.lgiglobal.com";  // logged in user
            ct.ModifiedOn = DateTime.Now;
            await _unitOfWork.MasterRepository.UpdateAsync(ct);
            await _unitOfWork.SaveAsync();
            return Json("Consignee Type " + model.Key + " updated successfully.");
        }

        #endregion

        #region ========== ContainerSizes ==========

        public IActionResult ContainerSizes()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetAllContainerSizes()
        {
            if (!ModelState.IsValid)
            {
                return Json("Invalid Model: " + ModelState);
            }
            return Json(await _unitOfWork.MasterRepository.GetAllAsync("CONTAINERSIZE"));
        }

        [HttpPost]
        public async Task<JsonResult> AddContainerSize(MasterItem model)
        {
            if (!ModelState.IsValid)
            {
                return Json("Invalid Model: " + ModelState);
            }

            await _unitOfWork.MasterRepository.AddAsync(model);
            await _unitOfWork.SaveAsync();
            return Json("Container size " + model.Key + " saved successfully.");
        }

        [HttpGet]
        public async Task<JsonResult> EditContainerSize(int id)
        {
            if (!ModelState.IsValid)
            {
                return Json("Invalid Model: " + ModelState);
            }

            var model = await _unitOfWork.MasterRepository.GetByIdAsync(id);
            return Json(model);
        }

        [HttpPost]
        public async Task<JsonResult> UpdateContainerSize(MasterItem model)
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
            ct.ModifiedBy = "murali.kunapareddy@vendor.lgiglobal.com";  // logged in user
            ct.ModifiedOn = DateTime.Now;
            await _unitOfWork.MasterRepository.UpdateAsync(ct);
            await _unitOfWork.SaveAsync();
            return Json("Container size " + model.Key + " updated successfully.");
        }

        [HttpGet]
        public async Task<JsonResult> SuspendContainerSize(int id)
        {
            if (!ModelState.IsValid)
            {
                return Json("Invalid Model: " + ModelState);
            }

            var model = await _unitOfWork.MasterRepository.GetByIdAsync(id);
            model.IsActive = !model.IsActive;
            model.ModifiedBy = "murali.kunapareddy@vendor.lgiglobal.com";  // logged in user
            model.ModifiedOn = DateTime.Now;
            await _unitOfWork.SaveAsync();
            if (model.IsActive)
                return Json("Container size <b>" + model.Key + "</b> reinstated successfully.");
            else
                return Json("Container size <b>" + model.Key + "</b> suspended successfully.");
        }

        #endregion

        #region ========== Incoterms ==========
        public IActionResult Incoterms()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetAllIncoterms()
        {
            if (!ModelState.IsValid)
            {
                return Json("Invalid Model: " + ModelState);
            }
            return Json(await _unitOfWork.MasterRepository.GetAllAsync("INCOTERM"));
        }

        [HttpPost]
        public async Task<JsonResult> AddIncoterm(MasterItem model)
        {
            if (!ModelState.IsValid)
            {
                return Json("Invalid Model: " + ModelState);
            }

            await _unitOfWork.MasterRepository.AddAsync(model);
            await _unitOfWork.SaveAsync();
            return Json("Incoterm " + model.Key + " saved successfully.");
        }
        [HttpGet]
        public async Task<JsonResult> EditIncoterm(int id)
        {
            if (!ModelState.IsValid)
            {
                return Json("Invalid Model: " + ModelState);
            }

            var model = await _unitOfWork.MasterRepository.GetByIdAsync(id);
            return Json(model);
        }
        [HttpGet]
        public async Task<JsonResult> SuspendIncoterm(int id)
        {
            if (!ModelState.IsValid)
            {
                return Json("Invalid Model: " + ModelState);
            }

            var model = await _unitOfWork.MasterRepository.GetByIdAsync(id);
            model.IsActive = !model.IsActive;
            model.ModifiedBy = "murali.kunapareddy@vendor.lgiglobal.com";  // logged in user
            model.ModifiedOn = DateTime.Now;
            await _unitOfWork.SaveAsync();
            if (model.IsActive)
                return Json("Incoterm <b>" + model.Key + "</b> reinstated successfully.");
            else
                return Json("Incoterm <b>" + model.Key + "</b> suspended successfully.");
        }
        [HttpPost]
        public async Task<JsonResult> UpdateIncoterm(MasterItem model)
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
            ct.ModifiedBy = "murali.kunapareddy@vendor.lgiglobal.com";  // logged in user
            ct.ModifiedOn = DateTime.Now;
            await _unitOfWork.MasterRepository.UpdateAsync(ct);
            await _unitOfWork.SaveAsync();
            return Json("Incoterm " + model.Key + " updated successfully.");
        }

        #endregion

        #region ========== PaperworksList ==========
        public IActionResult PaperworksList()
        {
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> GetAllPaperworkLists()
        {
            if (!ModelState.IsValid)
            {
                return Json("Invalid Model: " + ModelState);
            }
            return Json(await _unitOfWork.MasterRepository.GetAllAsync("PAPERWORK"));
        }

        [HttpPost]
        public async Task<JsonResult> AddPaperworkList(MasterItem model)
        {
            if (!ModelState.IsValid)
            {
                return Json("Invalid Model: " + ModelState);
            }

            await _unitOfWork.MasterRepository.AddAsync(model);
            await _unitOfWork.SaveAsync();
            return Json("PaperworkList " + model.Key + " saved successfully.");
        }

        [HttpGet]
        public async Task<JsonResult> EditPaperworkList(int id)
        {
            if (!ModelState.IsValid)
            {
                return Json("Invalid Model: " + ModelState);
            }

            var model = await _unitOfWork.MasterRepository.GetByIdAsync(id);
            return Json(model);
        }

        [HttpGet]
        public async Task<JsonResult> SuspendPaperworkList(int id)
        {
            if (!ModelState.IsValid)
            {
                return Json("Invalid Model: " + ModelState);
            }

            var model = await _unitOfWork.MasterRepository.GetByIdAsync(id);
            model.IsActive = !model.IsActive;
            model.ModifiedBy = "murali.kunapareddy@vendor.lgiglobal.com";  // logged in user
            model.ModifiedOn = DateTime.Now;
            await _unitOfWork.SaveAsync();
            if (model.IsActive)
                return Json("Paper Work <b>" + model.Key + "</b> reinstated successfully.");
            else
                return Json("Paper Work <b>" + model.Key + "</b> suspended successfully.");
        }

        [HttpPost]
        public async Task<JsonResult> UpdatePaperworkList(MasterItem model)
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
            ct.ModifiedBy = "murali.kunapareddy@vendor.lgiglobal.com";  // logged in user
            ct.ModifiedOn = DateTime.Now;
            await _unitOfWork.MasterRepository.UpdateAsync(ct);
            await _unitOfWork.SaveAsync();
            return Json("PaperworkList " + model.Key + " updated successfully.");
        }
        #endregion

        #region ========== PaymentTerms ==========
        public IActionResult PaymentTerms()
        {
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> GetAllPaymentTerms()
        {
            if (!ModelState.IsValid)
            {
                return Json("Invalid Model: " + ModelState);
            }
            return Json(await _unitOfWork.MasterRepository.GetAllAsync("PAYMENTTERM"));
        }

        [HttpPost]
        public async Task<JsonResult> AddPaymentTerm(MasterItem model)
        {
            if (!ModelState.IsValid)
            {
                return Json("Invalid Model: " + ModelState);
            }

            await _unitOfWork.MasterRepository.AddAsync(model);
            await _unitOfWork.SaveAsync();
            return Json("PaymentTerm <b>" + model.Key + " saved successfully.");
        }
        [HttpGet]
        public async Task<JsonResult> EditPaymentTerm(int id)
        {
            if (!ModelState.IsValid)
            {
                return Json("Invalid Model: " + ModelState);
            }

            var model = await _unitOfWork.MasterRepository.GetByIdAsync(id);
            return Json(model);
        }
        [HttpGet]
        public async Task<JsonResult> SuspendPaymentTerm(int id)
        {
            if (!ModelState.IsValid)
            {
                return Json("Invalid Model: " + ModelState);
            }

            var model = await _unitOfWork.MasterRepository.GetByIdAsync(id);
            model.IsActive = !model.IsActive;
            model.ModifiedBy = "murali.kunapareddy@vendor.lgiglobal.com";  // logged in user
            model.ModifiedOn = DateTime.Now;
            await _unitOfWork.SaveAsync();
            if (model.IsActive)
                return Json("Payment Term <b>" + model.Key + "</b> reinstated successfully.");
            else
                return Json("Payment Term <b>" + model.Key + "</b> suspended successfully.");
        }
        [HttpPost]
        public async Task<JsonResult> UpdatePaymentTerm(MasterItem model)
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
            ct.ModifiedBy = "murali.kunapareddy@vendor.lgiglobal.com";  // logged in user
            ct.ModifiedOn = DateTime.Now;
            await _unitOfWork.MasterRepository.UpdateAsync(ct);
            await _unitOfWork.SaveAsync();
            return Json("PaymentTerm " + model.Key + " updated successfully.");
        }
        #endregion

        #region ========== Ports ==========
        public IActionResult Ports()
        {
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> GetAllPorts()
        {
            if (!ModelState.IsValid)
            {
                return Json("Invalid Model: " + ModelState);
            }
            return Json(await _unitOfWork.MasterRepository.GetAllAsync("PORT"));
        }

        [HttpPost]
        public async Task<JsonResult> AddPort(MasterItem model)
        {
            if (!ModelState.IsValid)
            {
                return Json("Invalid Model: " + ModelState);
            }

            await _unitOfWork.MasterRepository.AddAsync(model);
            await _unitOfWork.SaveAsync();
            return Json("Port " + model.Value + " saved successfully.");
        }
        [HttpGet]
        public async Task<JsonResult> EditPort(int id)
        {
            if (!ModelState.IsValid)
            {
                return Json("Invalid Model: " + ModelState);
            }

            var model = await _unitOfWork.MasterRepository.GetByIdAsync(id);
            return Json(model);
        }
        [HttpGet]
        public async Task<JsonResult> SuspendPort(int id)
        {
            if (!ModelState.IsValid)
            {
                return Json("Invalid Model: " + ModelState);
            }

            var model = await _unitOfWork.MasterRepository.GetByIdAsync(id);
            model.IsActive = !model.IsActive;
            model.ModifiedBy = "murali.kunapareddy@vendor.lgiglobal.com";  // logged in user
            model.ModifiedOn = DateTime.Now;
            await _unitOfWork.SaveAsync();
            if (model.IsActive)
                return Json("Port <b>" + model.Key + "</b> reinstated successfully.");
            else
                return Json("Port <b>" + model.Key + "</b> suspended successfully.");
        }
        [HttpPost]
        public async Task<JsonResult> UpdatePort(MasterItem model)
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
            ct.ModifiedBy = "murali.kunapareddy@vendor.lgiglobal.com";  // logged in user
            ct.ModifiedOn = DateTime.Now;
            await _unitOfWork.MasterRepository.UpdateAsync(ct);
            await _unitOfWork.SaveAsync();
            return Json("Port " + model.Key + " updated successfully.");
        }
        #endregion

        #region ========== Products ==========
        public IActionResult Products()
        {
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> GetAllProducts()
        {
            if (!ModelState.IsValid)
            {
                return Json("Invalid Model: " + ModelState);
            }
            return Json(await _unitOfWork.ProductRepository.GetAllAsync());
        }

        [HttpPost]
        public async Task<JsonResult> AddProduct(Product model)
        {
            if (!ModelState.IsValid)
            {
                return Json("Invalid Model: " + ModelState);
            }

            await _unitOfWork.ProductRepository.AddAsync(model);
            await _unitOfWork.SaveAsync();
            return Json("Product " + model.Name + " saved successfully.");
        }
        [HttpGet]
        public async Task<JsonResult> EditProduct(int id)
        {
            if (!ModelState.IsValid)
            {
                return Json("Invalid Model: " + ModelState);
            }

            var model = await _unitOfWork.ProductRepository.GetByIdAsync(id);
            return Json(model);
        }
        [HttpGet]
        public async Task<JsonResult> SuspendProduct(int id)
        {
            if (!ModelState.IsValid)
            {
                return Json("Invalid Model: " + ModelState);
            }

            var model = await _unitOfWork.ProductRepository.GetByIdAsync(id);
            model.IsActive = !model.IsActive;
            model.ModifiedBy = "murali.kunapareddy@vendor.lgiglobal.com";  // logged in user
            model.ModifiedOn = DateTime.Now;
            await _unitOfWork.SaveAsync();
            if (model.IsActive)
                return Json("Product <b>" + model.Name + "</b> reinstated successfully.");
            else
                return Json("Product <b>" + model.Name + "</b> suspended successfully.");
        }
        [HttpPost]
        public async Task<JsonResult> UpdateProduct(Product model)
        {
            if (!ModelState.IsValid)
            {
                return Json("Invalid Model: " + ModelState);
            }

            var ct = await _unitOfWork.ProductRepository.GetByIdAsync(model.Id);
            ct.Code = model.Code;
            ct.Name = model.Name;
            ct.CompanyCode = model.CompanyCode;
            ct.ModifiedBy = "murali.kunapareddy@vendor.lgiglobal.com";  // logged in user
            ct.ModifiedOn = DateTime.Now;
            await _unitOfWork.ProductRepository.UpdateAsync(ct);
            await _unitOfWork.SaveAsync();
            return Json("Product " + model.Name + " updated successfully.");
        }
        #endregion

        #region ========== ShipVia ==========
        public IActionResult ShipVia()
        {
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> GetAllShipVias()
        {
            if (!ModelState.IsValid)
            {
                return Json("Invalid Model: " + ModelState);
            }
            return Json(await _unitOfWork.MasterRepository.GetAllAsync("ShipVia"));
        }

        [HttpPost]
        public async Task<JsonResult> AddShipVia(MasterItem model)
        {
            if (!ModelState.IsValid)
            {
                return Json("Invalid Model: " + ModelState);
            }

            await _unitOfWork.MasterRepository.AddAsync(model);
            await _unitOfWork.SaveAsync();
            return Json("ShipVia " + model.Key + " saved successfully.");
        }
        [HttpGet]
        public async Task<JsonResult> EditShipVia(int id)
        {
            if (!ModelState.IsValid)
            {
                return Json("Invalid Model: " + ModelState);
            }

            var model = await _unitOfWork.MasterRepository.GetByIdAsync(id);
            return Json(model);
        }
        [HttpGet]
        public async Task<JsonResult> SuspendShipVia(int id)
        {
            if (!ModelState.IsValid)
            {
                return Json("Invalid Model: " + ModelState);
            }

            var model = await _unitOfWork.MasterRepository.GetByIdAsync(id);
            model.IsActive = !model.IsActive;
            model.ModifiedBy = "murali.kunapareddy@vendor.lgiglobal.com";  // logged in user
            model.ModifiedOn = DateTime.Now;
            await _unitOfWork.SaveAsync();
            if (model.IsActive)
                return Json("Ship Via <b>" + model.Key + "</b> reinstated successfully.");
            else
                return Json("Ship Via <b>" + model.Key + "</b> suspended successfully.");
        }
        [HttpPost]
        public async Task<JsonResult> UpdateShipVia(MasterItem model)
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
            ct.ModifiedBy = "murali.kunapareddy@vendor.lgiglobal.com";  // logged in user
            ct.ModifiedOn = DateTime.Now;
            await _unitOfWork.MasterRepository.UpdateAsync(ct);
            await _unitOfWork.SaveAsync();
            return Json("ShipVia " + model.Key + " updated successfully.");
        }
        #endregion

    }
}
