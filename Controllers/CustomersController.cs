using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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
            var paperworksMaster = _unitOfWork.MasterRepository.GetAllAsync("PAPERWORK").Result;
            // Initialize CustomerPaperwork for each MasterItem
            var paperworks = paperworksMaster.Select(p => new CustomerPaperwork
            {
                PaperworkId = p.Id,
                Paperwork = p  // Assign the MasterItem
            }).ToList();

            // pass required master items
            var consigneeTypes = _unitOfWork.MasterRepository.GetAllAsync("CONSIGNEETYPE").Result;
            var paymentTerms = _unitOfWork.MasterRepository.GetAllAsync("PAYMENTTERM").Result;
            var incoterms = _unitOfWork.MasterRepository.GetAllAsync("INCOTERM").Result;

            consigneeTypes = consigneeTypes.Prepend(new MasterItem() { Id = 0, Name = "CONSIGNEETYPE", Key = "-Choose One-", Value = "0" }).ToList();
            paymentTerms = paymentTerms.Prepend(new MasterItem() { Id = 0, Name = "PAYMENTTERM", Key = "-Choose One-", Value = "0" }).ToList();
            incoterms = incoterms.Prepend(new MasterItem() { Id = 0, Name = "INCOTERM", Key = "-Choose One-", Value = "0" }).ToList();

            var addCustomer = new CustomerViewModel
            {
                Customer = new Customer
                {
                    BillToAddress = new Address(),
                    ShipToAddress = new Address(),
                    DocsSendToAddress = new Address(),
                    BrokerAddress = new Address(),
                    NotifyPartyAddress = new Address(),
                    BankAddress = new Address()
                },
                Paperworks = paperworks,
                ConsigneeTypes = consigneeTypes,
                PaymentTerms = paymentTerms,
                Incoterms = incoterms
            };
            return View(addCustomer);
        }

        #endregion

        #region ========== Customer Edit ==========

        [HttpGet]
        public async Task<IActionResult> EditCustomerAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Json("Invalid Model: " + ModelState);
            }

            var paperworksMaster = _unitOfWork.MasterRepository.GetAllAsync("PAPERWORK").Result;
            // Initialize CustomerPaperwork for each MasterItem
            var paperworks = paperworksMaster.Select(p => new CustomerPaperwork
            {
                PaperworkId = p.Id,
                Paperwork = p  // Assign the MasterItem
            }).ToList();

            // pass required master items
            var consigneeTypes = _unitOfWork.MasterRepository.GetAllAsync("CONSIGNEETYPE").Result;
            var paymentTerms = _unitOfWork.MasterRepository.GetAllAsync("PAYMENTTERM").Result;
            var incoterms = _unitOfWork.MasterRepository.GetAllAsync("INCOTERM").Result;

            consigneeTypes = consigneeTypes.Prepend(new MasterItem() { Id = 0, Name = "CONSIGNEETYPE", Key = "-Choose One-", Value = "0" }).ToList();
            paymentTerms = paymentTerms.Prepend(new MasterItem() { Id = 0, Name = "PAYMENTTERM", Key = "-Choose One-", Value = "0" }).ToList();
            incoterms = incoterms.Prepend(new MasterItem() { Id = 0, Name = "INCOTERM", Key = "-Choose One-", Value = "0" }).ToList();

            // get customer from id
            var model = await _unitOfWork.CustomerRepository.GetByIdAsync(id);
            var customerVM = new CustomerViewModel
            {
                Customer = model,
                Paperworks = paperworks,
                ConsigneeTypes = consigneeTypes,
                PaymentTerms = paymentTerms,
                Incoterms = incoterms
            };
            return View(customerVM);
        }

        #endregion

        #region ========== Customer Clear / Delete ==========
        [HttpPost]
        public IActionResult ClearCustomer(CustomerViewModel model)
        {
            return RedirectToAction("Index", "Customers");
        }

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

        #region ========== Customer Save ==========

        [HttpPost]
        public async Task<JsonResult> SaveCustomer(CustomerViewModel model)
        {
            // start populating model
            await ValidateCustomerModelAsync(model.Customer!);
            // end populating model
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = "Invalid Model: " + ModelState });
            }

            var customer = model.Customer!;

            try
            {
                // save customer first
                await _unitOfWork.CustomerRepository.AddAsync(customer);
                await _unitOfWork.SaveAsync();

                // save paperwork entries
                foreach (var paperwork in model.Paperworks)
                {
                    paperwork.CustomerId = model.Customer!.Id; // Link to the saved customer
                    await _unitOfWork.CustomerRepository.AddPaperworkAsync(paperwork);
                }
                await _unitOfWork.SaveAsync();

                return Json(new { success = true, message = "Customer saved successfully." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Failed to save customer: " + ex.Message });
            }
        }
        #endregion

        #region ========== Temp Functions ==========

        private async Task ValidateCustomerModelAsync(Customer customer)
        {
            try
            {
                //== billto 
                customer.BillToNo = string.IsNullOrEmpty(customer.BillToNo) ? "CUSTOM" : customer.BillToNo;
                customer.BillToName = string.IsNullOrEmpty(customer.BillToName) ? "CUSTOM" : customer.BillToName;
                customer.BillToAddress = await BuildAddressAsync(customer.BillToAddress!);
                customer.BillToAddressId = customer.BillToAddress.Id;
                //== shipto 
                customer.ShipToNo = string.IsNullOrEmpty(customer.BillToNo) ? "CUSTOM" : customer.BillToNo;
                customer.ShipToName = string.IsNullOrEmpty(customer.BillToName) ? "CUSTOM" : customer.BillToName;
                customer.ShipToAddress = await BuildAddressAsync(customer.ShipToAddress!);
                customer.ShipToAddressId = customer.ShipToAddress.Id;
                //== associated company
                customer.CompanyCode = (customer.CompanyCode != 0) ? customer.CompanyCode:999; // DEFAULTS TO CUSTOM  
                customer.Company = await _unitOfWork.CompanyRepository.GetByIdAsync(customer.CompanyCode);
                //== docs sent to
                customer.DocsSendToAddress = await BuildAddressAsync(customer.DocsSendToAddress!);
                customer.DocsSendToAddressId = customer.DocsSendToAddress.Id;
                customer.DocSendToNotes = string.IsNullOrEmpty(customer.DocSendToNotes) ? "CUSTOM" : customer.DocSendToNotes;
                //== broker
                customer.BrokerAddress = await BuildAddressAsync(customer.BrokerAddress!);
                customer.BrokerAddressId = customer.BrokerAddress.Id;
                //== notify party
                customer.NotifyPartyAddress = await BuildAddressAsync(customer.NotifyPartyAddress!);
                customer.NotifyPartyAddressId = customer.NotifyPartyAddress.Id;
                //== bank info
                customer.BankAddress = await BuildAddressAsync(customer.BankAddress!);
                customer.BankAddressId = customer.BankAddress.Id;
                //== emails
                customer.DocsDistributionEmails = string.IsNullOrEmpty(customer.DocsDistributionEmails) ? "CUSTOM" : customer.DocsDistributionEmails;
                customer.CustomerBookingEmails = string.IsNullOrEmpty(customer.CustomerBookingEmails) ? "CUSTOM" : customer.CustomerBookingEmails;
                //== aes notes & comments
                customer.UltimateConsgineeTypeId = (customer.UltimateConsgineeTypeId != 0) ? customer.UltimateConsgineeTypeId : 18; // DEFAULTS TO OTHER
                customer.UltimateConsgineeType = await _unitOfWork.MasterRepository.GetByIdAsync(customer.UltimateConsgineeTypeId);
                customer.ExportInfoCode = string.IsNullOrEmpty(customer.ExportInfoCode) ? "CUSTOM" : customer.ExportInfoCode;
                customer.LicenseCode = string.IsNullOrEmpty(customer.LicenseCode) ? "CUSTOM" : customer.LicenseCode;
                customer.LicenseNo = string.IsNullOrEmpty(customer.LicenseNo) ? "CUSTOM" : customer.LicenseNo;
                customer.PaymentTermId = (customer.PaymentTermId != 0) ? customer.PaymentTermId : 1; // DEFAULTS TO PAY IN ADVANCE
                customer.PaymentTerm = await _unitOfWork.MasterRepository.GetByIdAsync(customer.PaymentTermId);
                customer.Incoterm2020Id = (customer.Incoterm2020Id != 0) ? customer.Incoterm2020Id : 10; // DEFAULTS TO 10 - FCA
                customer.Incoterm2020 = await _unitOfWork.MasterRepository.GetByIdAsync(customer.Incoterm2020Id);
                //== text comments
                customer.ImportPermitNotes = string.IsNullOrEmpty(customer.ImportPermitNotes) ? "CUSTOM" : customer.ImportPermitNotes;
                customer.ExportComments = string.IsNullOrEmpty(customer.ExportComments) ? "CUSTOM" : customer.ExportComments;
                customer.OldNotes = string.IsNullOrEmpty(customer.OldNotes) ? "CUSTOM" : customer.OldNotes;
                //== paperwork list + attachments
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", "Error in validating customer model: " + ex.Message);
            }
        }

        private async Task<Address> BuildAddressAsync(Address address)
        {
            try
            {
                Address NewAddress = new Address
                {
                    ContactName = string.IsNullOrEmpty(address.ContactName) ? "CUSTOM" : address.ContactName,
                    Name = string.IsNullOrEmpty(address.Name) ? "CUSTOM" : address.Name,
                    AddressLine = string.IsNullOrEmpty(address.AddressLine) ? "CUSTOM" : address.AddressLine,
                    City = string.IsNullOrEmpty(address.City) ? "CUSTOM" : address.City,
                    State = string.IsNullOrEmpty(address.State) ? "CUSTOM" : address.State,
                    CountryCode = string.IsNullOrEmpty(address.CountryCode) ? "IN" : address.CountryCode,
                    Zip = string.IsNullOrEmpty(address.Zip) ? "CUSTOM" : address.Zip,
                    Phone = string.IsNullOrEmpty(address.Phone) ? "CUSTOM" : address.Phone,
                    Fax = string.IsNullOrEmpty(address.Fax) ? "CUSTOM" : address.Fax,
                    Email = string.IsNullOrEmpty(address.Email) ? "CUSTOM" : address.Email,
                    Website = string.IsNullOrEmpty(address.Website) ? "CUSTOM" : address.Website,
                    TaxId = string.IsNullOrEmpty(address.TaxId) ? "CUSTOM" : address.TaxId,
                    VATNo = string.IsNullOrEmpty(address.VATNo) ? "CUSTOM" : address.VATNo,
                    AdditionalEmails = string.IsNullOrEmpty(address.AdditionalEmails) ? "CUSTOM" : address.AdditionalEmails,
                    //
                    CreatedBy = "murali.kunapareddy@bhjgroup.onmicrosoft.com"
                };

                // save to database
                await _unitOfWork.CustomerRepository.AddAddressAsync(NewAddress);
                await _unitOfWork.SaveAsync();

                return NewAddress;
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", "Error in building address: " + ex.Message);
                return new Address();
            }
        }

        private async Task<CustomerPaperwork> BuildPaperworkAsync(CustomerPaperwork customerPaperwork)
        {
            try
            {
                // save to database
                await _unitOfWork.CustomerRepository.AddPaperworkAsync(customerPaperwork);
                await _unitOfWork.SaveAsync();

                return customerPaperwork;
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("Error", "Error in building address: " + ex.Message);
                return new CustomerPaperwork();
            }
        }

        #endregion
    }
}
