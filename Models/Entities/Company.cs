using System.ComponentModel.DataAnnotations;
using WISSEN.EDA.Data;

namespace WISSEN.EDA.Models.Entities
{
    public class Company : BaseTable
    {
        [Key]
        [StringLength(5)]
        public int Code { get; set; }
        [Required(ErrorMessage = "Company Name is required")]
        [StringLength(50)]
        public string? Name { get; set; }
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
        public Country? Country { get; set; }
        [Required(ErrorMessage = "Country is required")]
        [StringLength(10)]
        public string? zip { get; set; }
        [StringLength(15)]
        public string? Phone { get; set; }
        [StringLength(15)]
        public string? Fax { get; set; }
        [StringLength(100)]
        [EmailAddress(ErrorMessage = "Invalid email")]
        public string? Email { get; set; }
        public string? Logo { get; set; }
    }
}
