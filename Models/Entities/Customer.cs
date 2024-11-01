using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WISSEN.EDA.Data;

namespace WISSEN.EDA.Models.Entities
{
    public class Customer : BaseTable
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Customer no is required")]
        [StringLength(8)]
        public string? BillToNo { get; set; }

        [Required(ErrorMessage = "Customer name is required")]
        [StringLength(100)]
        public string? BillToName { get; set; }

        [Required(ErrorMessage = "Shipping no is required")]
        [StringLength(8)]
        public string? ShipToNo { get; set; }

        [Required(ErrorMessage = "Shipping name is required")]
        [StringLength(100)]
        public string? ShipToName { get; set; }



        [StringLength(100)]
        public string? AddressLine1 { get; set; }
        
        [StringLength(100)]
        public string? AddressLine2 { get; set; }
        
        [Required(ErrorMessage = "City is required")]
        [StringLength(50)]
        public string? City { get; set; }
        
        [Required(ErrorMessage = "State is required")]
        [StringLength(50)]
        public string? State { get; set; }
        
        [Required(ErrorMessage = "Country is required")]
        [StringLength(2)]
        public string? CountryCode { get; set; }
        
        [ForeignKey("CountryCode")]
        public Country? Country { get; set; }
        
        [Required(ErrorMessage = "Zip is required")]
        [StringLength(10)]
        public string? Zip { get; set; }
        
        [StringLength(15)]
        public string? Phone { get; set; }
        
        [StringLength(15)]
        public string? Fax { get; set; }
        
        [StringLength(100)]
        [EmailAddress(ErrorMessage = "Invalid email")]
        public string? Email { get; set; }
        public string? Logo { get; set; }

        public virtual ICollection<Product>? Products { get; set; }
    }
}
