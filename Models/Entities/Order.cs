using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using WISSEN.EDA.Data;

namespace WISSEN.EDA.Models.Entities
{
    public class Order : BaseTable
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Sales representative is required")]
        public string? SalesRepName { get; set; }

        [Required(ErrorMessage = "Customer PO no is required")]
        public string? CustomerPONo { get; set; }

        [Required(ErrorMessage = "Contract no is required")]
        public string? ContractNo { get; set; }

        [Required(ErrorMessage = "Order date is required")]
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "Customer 'Bill To' no is required")]
        public string? BillToNo { get; set; }

        [Required(ErrorMessage = "Customer 'Ship To' no is required")]
        public string? ShipToNo { get; set; }

        [Required(ErrorMessage = "Ship via is required")]
        public string? ShipVia { get; set; }

        public bool IsImportPermitRequired { get; set; }

        public bool IsPermitReceived { get; set; }

        [Required(ErrorMessage = "Container size need to be selected")]
        public int ContainerSizeId { get; set; }

        [ForeignKey("ContainerSizeId")]
        public MasterItem? ContainerSize { get; set; }

        public int RequestContainerLoading { get; set; }

        [Required(ErrorMessage = "Requested ETA date is required")]
        public DateTime RequestedETA { get; set; }

        public string? SpecialShippingInstructions { get; set; }

        public string? SpecialSKU { get; set; }

        public bool IsSepareteChargeApplicable { get; set; }

        public double FloorLoadChargeRate { get; set; }

        public bool IsFloorLoarChargeIncluded { get; set; }

        public double PalletChargeRate { get; set; }

        public bool IsPalletChargeIncluded { get; set; }

        public string? AdditionalNotes { get; set; }

        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public Customer? Customer { get; set; }
    }
}
