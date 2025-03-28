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
            var viewModel = InitializeCustomerViewModel();
            return View("Customer", viewModel);
        }

        #endregion

        #region ========== Customer Edit ==========

        [HttpGet]
        public async Task<IActionResult> EditCustomerAsync(int id)
        {
            var customer = await _unitOfWork.CustomerRepository.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            // load company details
            customer.Company = await _unitOfWork.CompanyRepository.GetByIdAsync(customer.CompanyCode);
            // load billto address
            customer.BillToAddress ??= await _unitOfWork.CustomerRepository.GetAddressByIdAsync(customer.BillToAddressId) ?? new Address();
            // load shipto address
            customer.ShipToAddress ??= await _unitOfWork.CustomerRepository.GetAddressByIdAsync(customer.ShipToAddressId) ?? new Address();
            // load docssendto address
            customer.DocsSendToAddress ??= await _unitOfWork.CustomerRepository.GetAddressByIdAsync(customer.DocsSendToAddressId) ?? new Address();
            // load broker address
            customer.BrokerAddress ??= await _unitOfWork.CustomerRepository.GetAddressByIdAsync(customer.BrokerAddressId) ?? new Address();
            // load notify party address
            customer.NotifyPartyAddress ??= await _unitOfWork.CustomerRepository.GetAddressByIdAsync(customer.NotifyPartyAddressId) ?? new Address();
            // bank address
            customer.BankAddress ??= await _unitOfWork.CustomerRepository.GetAddressByIdAsync(customer.BankAddressId) ?? new Address();
            // master paper works
            var paperworksMaster = _unitOfWork.MasterRepository.GetAllAsync("PAPERWORK").Result;
            // Load existing paperwork for the customer
            var existingPaperworks = await _unitOfWork.CustomerRepository.GetPaperworksByCustomerIdAsync(id);
            // Merge with master paperwork list
            var paperworks = paperworksMaster.Select(p => new CustomerPaperwork
            {
                CustomerId = id,
                PaperworkId = p.Id,
                Paperwork = p,
                Required = existingPaperworks.FirstOrDefault(ep => ep.PaperworkId == p.Id)?.Required ?? false,
                OriginalQuantity = existingPaperworks.FirstOrDefault(ep => ep.PaperworkId == p.Id)?.OriginalQuantity ?? 0,
                CopyQuantity = existingPaperworks.FirstOrDefault(ep => ep.PaperworkId == p.Id)?.CopyQuantity ?? 0
            }).ToList();
            // pass required master items
            var consigneeTypes = _unitOfWork.MasterRepository.GetAllAsync("CONSIGNEETYPE").Result;
            var paymentTerms = _unitOfWork.MasterRepository.GetAllAsync("PAYMENTTERM").Result;
            var incoterms = _unitOfWork.MasterRepository.GetAllAsync("INCOTERM").Result;

            consigneeTypes = consigneeTypes.Prepend(new MasterItem() { Id = 0, Name = "CONSIGNEETYPE", Key = "-Choose One-", Value = "0" }).ToList();
            paymentTerms = paymentTerms.Prepend(new MasterItem() { Id = 0, Name = "PAYMENTTERM", Key = "-Choose One-", Value = "0" }).ToList();
            incoterms = incoterms.Prepend(new MasterItem() { Id = 0, Name = "INCOTERM", Key = "-Choose One-", Value = "0" }).ToList();

            var customerVM = new CustomerViewModel
            {
                Customer = customer,
                Paperworks = paperworks,
                ConsigneeTypes = consigneeTypes,
                PaymentTerms = paymentTerms,
                Incoterms = incoterms
            };

            return View("Customer", customerVM);
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
            // TEST - start populating model
            model.Customer = await ValidateCustomerModelAsync(model.Customer!);
            // end populating model

            // skip model validation
            //if (!ModelState.IsValid)
            //{
            //    return Json(new { success = false, message = "Invalid Model: " + ModelState });
            //}

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
                    paperwork.CreatedBy = "murali.kunapareddy@bhjgroup.onmicrosoft.com";    //TODO: logged in user
                    paperwork.CreatedOn = DateTime.Now;
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

        #region ========== Customer Update ==========

        [HttpPost]
        public async Task<JsonResult> UpdateCustomer(CustomerViewModel model)
        {
            // skip model validation
            //if (!ModelState.IsValid)
            //{
            //    return Json(new { success = false, message = "Invalid Model: " + ModelState });
            //}

            try
            {
                // Update customer
                var customer = await ValidateCustomerModelAsync(model.Customer!);
                await _unitOfWork.CustomerRepository.UpdateAsync(customer);

                // Update paperwork
                foreach (var paperwork in model.Paperworks)
                {
                    paperwork.CustomerId = customer.Id;
                    var existing = await _unitOfWork.CustomerRepository.GetPaperworkAsync(customer.Id, paperwork.PaperworkId);

                    if (existing != null)
                    {
                        // Update existing
                        existing.Required = paperwork.Required;
                        existing.OriginalQuantity = paperwork.OriginalQuantity;
                        existing.CopyQuantity = paperwork.CopyQuantity;
                        existing.ModifiedBy = "murali.kunapareddy@bhjgroup.onmicrosoft.com"; // TODO: Set current user
                        existing.ModifiedOn = DateTime.Now;
                        await _unitOfWork.CustomerRepository.UpdatePaperworkAsync(existing);
                    }
                    else
                    {
                        // Add new
                        paperwork.CreatedBy = "murali.kunapareddy@bhjgroup.onmicrosoft.com"; // TODO: Set current user
                        paperwork.CreatedOn = DateTime.Now;
                        await _unitOfWork.CustomerRepository.AddPaperworkAsync(paperwork);
                    }
                }

                await _unitOfWork.SaveAsync();
                return Json(new { success = true, message = "Customer updated successfully." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Failed to update customer: " + ex.Message });
            }
        }

        #endregion

        #region ========== Temp Functions ==========

        private CustomerViewModel InitializeCustomerViewModel()
        {
            var paperworksMaster = _unitOfWork.MasterRepository.GetAllAsync("PAPERWORK").Result;
            var paperworks = paperworksMaster.Select(p => new CustomerPaperwork
            {
                PaperworkId = p.Id,
                Paperwork = p
            }).ToList();

            var consigneeTypes = _unitOfWork.MasterRepository.GetAllAsync("CONSIGNEETYPE").Result;
            var paymentTerms = _unitOfWork.MasterRepository.GetAllAsync("PAYMENTTERM").Result;
            var incoterms = _unitOfWork.MasterRepository.GetAllAsync("INCOTERM").Result;

            // Prepend default options
            consigneeTypes = consigneeTypes.Prepend(new MasterItem() { Id = 0, Name = "CONSIGNEETYPE", Key = "-Choose One-", Value = "0" }).ToList();
            paymentTerms = paymentTerms.Prepend(new MasterItem() { Id = 0, Name = "PAYMENTTERM", Key = "-Choose One-", Value = "0" }).ToList();
            incoterms = incoterms.Prepend(new MasterItem() { Id = 0, Name = "INCOTERM", Key = "-Choose One-", Value = "0" }).ToList();

            return new CustomerViewModel
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
        }

        private async Task<Customer> ValidateCustomerModelAsync(Customer customer)
        {
            try
            {
                //== billto 
                customer.BillToNo = string.IsNullOrEmpty(customer.BillToNo) ? "CUSTOM" : customer.BillToNo;
                customer.BillToName = string.IsNullOrEmpty(customer.BillToName) ? "CUSTOM" : customer.BillToName;
                customer.BillToAddress = customer.BillToAddressId > 0 ? await _unitOfWork.CustomerRepository.GetAddressByIdAsync(customer.BillToAddressId) : new Address();
                customer.BillToAddressId = customer.BillToAddress.Id;
                //== shipto 
                customer.ShipToNo = string.IsNullOrEmpty(customer.ShipToNo) ? "CUSTOM" : customer.ShipToNo;
                customer.ShipToName = string.IsNullOrEmpty(customer.ShipToName) ? "CUSTOM" : customer.ShipToName;
                customer.ShipToAddress = customer.ShipToAddressId > 0 ? await _unitOfWork.CustomerRepository.GetAddressByIdAsync(customer.ShipToAddressId) : new Address();
                customer.ShipToAddressId = customer.ShipToAddress.Id;
                //== associated company
                customer.CompanyCode = (customer.CompanyCode != 0) ? customer.CompanyCode : 999; // DEFAULTS TO CUSTOM  
                customer.Company = await _unitOfWork.CompanyRepository.GetByIdAsync(customer.CompanyCode);
                //== docs sent to
                customer.DocsSendToAddress = customer.DocsSendToAddressId > 0 ? await _unitOfWork.CustomerRepository.GetAddressByIdAsync(customer.DocsSendToAddressId) : new Address();
                customer.DocsSendToAddressId = customer.DocsSendToAddress.Id;
                customer.DocSendToNotes = string.IsNullOrEmpty(customer.DocSendToNotes) ? "CUSTOM" : customer.DocSendToNotes;
                //== broker
                customer.BrokerAddress = customer.BrokerAddressId > 0 ? await _unitOfWork.CustomerRepository.GetAddressByIdAsync(customer.BrokerAddressId) : new Address();
                customer.BrokerAddressId = customer.BrokerAddress.Id;
                //== notify party
                customer.NotifyPartyAddress = customer.NotifyPartyAddressId > 0 ? await _unitOfWork.CustomerRepository.GetAddressByIdAsync(customer.NotifyPartyAddressId) : new Address();
                customer.NotifyPartyAddressId = customer.NotifyPartyAddress.Id;
                //== bank info
                customer.BankAddress = customer.BankAddressId > 0 ? await _unitOfWork.CustomerRepository.GetAddressByIdAsync(customer.BankAddressId) : new Address();
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
                customer.PaymentTermId = (customer.PaymentTermId != 0) ? customer.PaymentTermId : 117; // DEFAULTS TO PAY IN ADVANCE
                customer.PaymentTerm = await _unitOfWork.MasterRepository.GetByIdAsync(customer.PaymentTermId);
                customer.Incoterm2020Id = (customer.Incoterm2020Id != 0) ? customer.Incoterm2020Id : 71; // DEFAULTS TO 10 - FCA
                customer.Incoterm2020 = await _unitOfWork.MasterRepository.GetByIdAsync(customer.Incoterm2020Id);
                //== text comments
                customer.ImportPermitNotes = string.IsNullOrEmpty(customer.ImportPermitNotes) ? "CUSTOM" : customer.ImportPermitNotes;
                customer.ExportComments = string.IsNullOrEmpty(customer.ExportComments) ? "CUSTOM" : customer.ExportComments;
                customer.OldNotes = string.IsNullOrEmpty(customer.OldNotes) ? "CUSTOM" : customer.OldNotes;
                //== created by
                customer.CreatedBy = "murali.kunapareddy@bhjgroup.onmicrosoft.com"; // TODO: logged in user
                customer.CreatedOn = DateTime.Now;
                return customer;
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", "Error in validating customer model: " + ex.Message);
                return new Customer();
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

        #endregion
    }
}
