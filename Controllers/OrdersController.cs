using Microsoft.AspNetCore.Mvc;

using WISSEN.EDA.Models.Entities;
using WISSEN.EDA.Models.ViewModels;
using WISSEN.EDA.Repositories;

namespace EDA.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrdersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        #region ========== Orders List ==========

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetAllOrders()
        {
            if (!ModelState.IsValid)
            {
                return Json("Invalid Model: " + ModelState);
            }
            return Json(await _unitOfWork.OrderRepository.GetAllAsync());
        }

        #endregion

        #region ========== Order Add ==========

        public IActionResult AddOrder()
        {
            var viewModel = InitializeOrderViewModel();
            return View("Order", viewModel);
        }

        #endregion

        #region ========== Temp Functions ==========

        private OrderViewModel InitializeOrderViewModel()
        {
            var consigneeTypes = _unitOfWork.MasterRepository.GetAllAsync("CONSIGNEETYPE").Result;
            var countries = _unitOfWork.CommonRepository.GetCountriesAsync().Result;

            // Prepend default options
            consigneeTypes = [.. consigneeTypes.Prepend(new MasterItem() { Id = 0, Name = "CONSIGNEETYPE", Key = "-Choose One-", Value = "0" })];
            countries = [.. countries.Prepend(new Country() { Code = "0", Name = "-Choose One-" })];

            return new OrderViewModel
            {
                Order = new Order(),
                ConsigneeTypes = consigneeTypes
            };

            #endregion
        }
    }
}
