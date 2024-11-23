using WISSEN.EDA.Data;
using WISSEN.EDA.Models.Entities;

namespace WISSEN.EDA.Models.ViewModels
{
	public class CustomerViewModel: BaseTable
	{
		public int Id { get; set; }
		public string? BillToNo { get; set; }
		public string? BillToName { get; set; }
		public string? ShipToNo { get; set; }
		public string? ShipToName { get; set; }
		public int CompanyCode { get; set; }
		public string? CompanyName { get; set; }

		public int CustomerAddressId { get; set; }
		public string? CustomerContactName { get; set; }
		public string? CustomerName { get; set; }
		public string? CustomerAddress { get; set;}
		public string? CustomerCity { get; set;}
		public string? CustomerState { get; set;}
		public string? CustomerCountry { get; set;}
		public string? CustomerZip { get; set;}
		public string? CustomerPhone { get; set;}
		public string? CustomerEmail { get; set;}
		public string? CustomerWebsite { get; set;}
		public string? CustomerTaxId { get; set;}
		public string? CustomerVATNo { get; set;}
		public string? CustomerAdditionalEmails { get; set;}

        public int ConsigneeAddressId { get; set; }
        public string? ConsigneeContactName { get; set; }
        public string? ConsigneeName { get; set; }
        public string? ConsigneeAddress { get; set; }
        public string? ConsigneeCity { get; set; }
        public string? ConsigneeState { get; set; }
        public string? ConsigneeCountry { get; set; }
        public string? ConsigneeZip { get; set; }
        public string? ConsigneePhone { get; set; }
        public string? ConsigneeEmail { get; set; }
        public string? ConsigneeWebsite { get; set; }
        public string? ConsigneeTaxId { get; set; }
        public string? ConsigneeVATNo { get; set; }
        public string? ConsigneeAdditionalEmails { get; set; }

        public int DocSendToAddressId { get; set; }
        public string? DocSendToContactName { get; set; }
        public string? DocSendToName { get; set; }
        public string? DocSendToAddress { get; set; }
        public string? DocSendToCity { get; set; }
        public string? DocSendToState { get; set; }
        public string? DocSendToCountry { get; set; }
        public string? DocSendToZip { get; set; }
        public string? DocSendToPhone { get; set; }
        public string? DocSendToEmail { get; set; }
        public string? DocSendToNotes { get; set; }
        public string? DocSendToAdditionalEmails { get; set; }

        public int BrokerAddressId { get; set; }
        public string? BrokerContactName { get; set; }
        public string? BrokerName { get; set; }
        public string? BrokerAddress { get; set; }
        public string? BrokerCity { get; set; }
        public string? BrokerState { get; set; }
        public string? BrokerCountry { get; set; }
        public string? BrokerZip { get; set; }
        public string? BrokerPhone { get; set; }
        public string? BrokerEmail { get; set; }
        public string? BrokerAdditionalEmails { get; set; }

        public int NotifyPartyAddressId { get; set; }
        public string? NotifyPartyContactName { get; set; }
        public string? NotifyPartyName { get; set; }
        public string? NotifyPartyAddress { get; set; }
        public string? NotifyPartyCity { get; set; }
        public string? NotifyPartyState { get; set; }
        public string? NotifyPartyCountry { get; set; }
        public string? NotifyPartyZip { get; set; }
        public string? NotifyPartyPhone { get; set; }
        public string? NotifyPartyEmail { get; set; }
        public string? NotifyPartyAdditionalEmails { get; set; }


        public int BankAddressId { get; set; }
        public string? BankContactName { get; set; }
        public string? BankName { get; set; }
        public string? BankAddress { get; set; }
        public string? BankCity { get; set; }
        public string? BankState { get; set; }
        public string? BankCountry { get; set; }
        public string? BankZip { get; set; }
        public string? BankPhone { get; set; }
        public string? BankEmail { get; set; }

        public string? DistributionEmails { get; set; }
        public int ConsigneeTypeId { get; set; }
        public string? ConsigneeType { get; }
        public string? ExportInfoCode { get; set; }
        public string? LicenseCode { get; set; }
        public string? LicenseNo { get; set; }
        public bool RoutedTransaction { get; set; }

        public int PaymentTermId { get; set; }
        public string? PaymentTerms { get; }
        public int IncotermId { get; set; }
        public string? Incoterm { get; }
        public bool ProformaInvoice { get; set; }
        public bool Picture { get; set; }
        public bool ImportPermit { get; set; }
        public string? CustomerBookingEmails { get; set;}

        public string? ImportPermitNotes { get; set; }
        public string? ExportComments { get; set; }
        public string? OldNotes { get; set; }

        public List<PaperworksViewModel>? Paperworks { get; set; }
    }
}
