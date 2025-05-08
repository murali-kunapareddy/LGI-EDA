using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

using WISSEN.EDA.Data;

namespace WISSEN.EDA.Models.Entities
{
    public class OrderItem: BaseTable
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Destination port is required")]
        public string? DestinationPort { get; set; }
        [Required(ErrorMessage = "Product is required")]
        public string? Product { get; set; }
        [Required(ErrorMessage = "Quantity is required")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Bag/Tote size is required")] 
        public double BagToteSize { get; set; }
        [Required(ErrorMessage = "No of Bags or Totes")]
        public int NoOfBagsTotes { get; set; }
        [Required(ErrorMessage = "FCA is required")]
        public double FCA { get; set; }
        [Required(ErrorMessage = "Fright charge is required")]
        public double Fright { get; set; }
        [Required(ErrorMessage = "Inusranace unit is required")]
        public double Insurance { get; set; }
        [Required(ErrorMessage = "Commission is required")]
        public double Commission { get; set; }
        public double FloorPalletCharge { get; set; }
        public double TotalSalesPerWeight { get; set; }
        public double TotalSalesOnOrder { get; set; }
        public double EachPrice { get; set; }
        public double SalesPricePerLoad { get; set; }
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order? Order { get; set; }
    }
}
