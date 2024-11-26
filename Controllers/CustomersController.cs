using Microsoft.AspNetCore.Mvc;
using WISSEN.EDA.Models.Entities;
using WISSEN.EDA.Models.ViewModels;
using WISSEN.EDA.Repositories;

namespace EDA.Controllers
{
    public class CustomersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

		#region ========== Customer List ==========

        public IActionResult Index()
        {
            return View();
        }

		[HttpGet]
        public async Task<JsonResult> GetAllCustomers()
        {
            if (!ModelState.IsValid)
            {
                return Json("Invalid Model: " + ModelState);
            }
            return Json(await _unitOfWork.CustomerRepository.GetAllAsync());
        }


		#endregion

		#region ========== Customer Add ==========

		public IActionResult AddCustomer()
		{
            // pass paperworks
            // var paperworks = _unitOfWork.CommonRepository.GetDDLSelectedMasters("PAPERWORK");
            var paperworks = _unitOfWork.MasterRepository.GetAllAsync("PAPERWORK").Result;
            //var customer = new Customer();
            var addCustomer = new AddCustomerViewModel();
            addCustomer.Paperworks = paperworks;
            return View(addCustomer);
		}

        #endregion

        #region ========== Customer Edit ==========

        [HttpGet]
		public IActionResult EditCustomer(int id)
		{
            // get customer from id
            ViewBag.Id = id;
			return View();
		}

		#endregion

		#region ========== Customer Delete ==========

		[HttpGet]
        public async Task<JsonResult> SuspendCustomer(int id)
        {
            if (!ModelState.IsValid)
            {
                return Json("Invalid Model: " + ModelState);
            }

            var model = await _unitOfWork.CustomerRepository.GetByIdAsync(id);
            model.IsActive = !model.IsActive;
            model.ModifiedBy = "murali.kunapareddy@vendor.lgiglobal.com";  // logged in user
            model.ModifiedOn = DateTime.Now;
            await _unitOfWork.SaveAsync();
            if (model.IsActive)
                return Json("Customer <b>" + model.BillToName + "</b> reinstated successfully.");
            else
                return Json("Customer <b>" + model.BillToName + "</b> suspended successfully.");
		}

		#endregion
	}
}   
        