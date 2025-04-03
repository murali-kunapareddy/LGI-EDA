using Microsoft.Extensions.Diagnostics.HealthChecks;

using System.ComponentModel.DataAnnotations;

using WISSEN.EDA.Data;

namespace WISSEN.EDA.Models.Entities
{
    public class Order : BaseTable
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string SalesRepName { get; set; }

        public string CustomerPONo { get; set; }

        public string ContractNo { get; set; }

        public DateTime OrderDate { get; set; }

        public string BillToNo { get; set; }

        public string ShipToNo { get; set; }

        public string ShipVia { get; set; }

        public int Incoterm { get; set; }
        public int PaymentTerm { get; set; }
        public bool IsImportPermitRequired { get; set; }
        public bool IsPermitReceived { get; set; }
        public int ContainerSize { get; set; }
        public bool IsProformaInvoiceNeeded { get; set; }
        public int RequestContainerLoading { get; set; }
        public DateTime RequestedETA { get; set; }
        public string SpecialShippingInstructions { get; set; }
        public string SpecialSKU { get; set; }
        public bool IsSepareteChargeApplicable { get; set; }
        public double FloorLoadChargeRate { get; set; }
        public bool IsFloorLoarChargeIncluded { get; set; }
        public double PalletChargeRate { get; set; }
        public bool IsPalletChargeIncluded { get; set; }
        public string AdditionalNotes { get; set; }
    }
}
