using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;
using WISSEN.EDA.Data;

namespace WISSEN.EDA.Models.Entities
{
    public class Customer : BaseTable
    {
        [Key]
        public int Id { get; set; }
        
        //== Bill to
        [Required(ErrorMessage = "Customer 'Bill To' no is required")]
        [StringLength(8)]
        public string? BillToNo { get; set; }

        [Required(ErrorMessage = "Customer 'Bill To' name is required")]
        [StringLength(100)]
        public string? BillToName { get; set; }

        [Required(ErrorMessage = "Customer 'Bill To' address is required")]
        public int BillToAddressId { get; set; }

        [ForeignKey("BillToAddressId")]
        public Address? BillToAddress { get; set; } = new Address();

        //== Ship To
        [Required(ErrorMessage = "Customer 'Ship To' no is required")]
        [StringLength(8)]
        public string? ShipToNo { get; set; }

        [Required(ErrorMessage = "Customer 'Ship To' name is required")]
        [StringLength(100)]
        public string? ShipToName { get; set; }

        [Required(ErrorMessage = "Customer 'Ship To' address is required")]
        public int ShipToAddressId { get; set; }

        [ForeignKey("ShipToAddressId")]
        public Address? ShipToAddress { get; set; } = new Address();

        //== associated company
        [Required(ErrorMessage = "Associated company is requried")]
        public int CompanyCode { get; set; }

        [ForeignKey("CompanyCode")]
        public Company? Company { get; set; }

        //== docs sent to
        [Required(ErrorMessage = "Documents Send To address is required")]
        public int DocsSendToAddressId { get; set; }

        [ForeignKey("DocsSendToAddressId")]
        public Address? DocsSendToAddress { get; set; } = new Address();

        [StringLength(200)]
        public string? DocSendToNotes { get; set; }

        //== broker
        [Required(ErrorMessage = "Broker address is required")]
        public int BrokerAddressId { get; set; }

        [ForeignKey("BrokerAddressId")]
        public Address? BrokerAddress { get; set; } = new Address();

        //== notify party
        public int NotifyPartyAddressId { get; set; }

        [ForeignKey("NotifyPartyAddressId")]
        public Address? NotifyPartyAddress { get; set; } = new Address();

        //== bank info
        public int BankAddressId { get; set; }

        [ForeignKey("BankAddressId")]
        public Address? BankAddress { get; set; } = new Address();

        //== emails
        [StringLength(1000)]
        public string? DocsDistributionEmails { get; set; }

        [StringLength(1000)]
        public string? CustomerBookingEmails { get; set; }

        //== aes notes & comments
        public int UltimateConsgineeTypeId { get; set; }

        [ForeignKey("UltimateConsgineeTypeId")]
        public MasterItem? UltimateConsgineeType { get; set; }

        [StringLength(10)]
        public string? ExportInfoCode { get; set; }

        [StringLength(10)]
        public string? LicenseCode { get; set; }

        [StringLength(10)]
        public string? LicenseNo { get; set; }

        public bool RoutedTransaction { get; set; }

        public int PaymentTermId {  get; set; }

        [ForeignKey("PaymentTermId")]
        public MasterItem? PaymentTerm { get; set; }

        public int Incoterm2020Id { get; set; }

        [ForeignKey("Incoterm2020Id")]
        public MasterItem? Incoterm2020 { get; set; }

        public bool ProformaInvoiceRequired { get; set; }

        public bool PictureRequired { get; set; }

        public bool ImportPermitRequired { get; set; }

        //== text comments
        [StringLength(500)]
        public string? ImportPermitNotes { get; set; }

        [StringLength(500)]
        public string? ExportComments { get; set; }

        [StringLength(500)]
        public string? OldNotes { get; set; }

        //== paperwork list + attachments
        public virtual ICollection<MasterItem>? Paperworks { get; set;}
        
        public virtual ICollection<CustomerAttachment>? CustomerAttachments { get; set;}
    }
}
