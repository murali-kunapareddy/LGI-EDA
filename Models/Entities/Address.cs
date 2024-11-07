using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WISSEN.EDA.Data;

namespace WISSEN.EDA.Models.Entities
{
    public class Address : BaseTable
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string? ContactName { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Address line is required")]
        [StringLength(150)]
        public string? AddressLine { get; set; }

        [Required(ErrorMessage = "City is required")]
        [StringLength(50)]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required")]
        [StringLength(50)]
        public string State { get; set; }

        [Required(ErrorMessage = "Country is required")]
        [StringLength(2)]
        public string? CountryCode { get; set; }

        [ForeignKey("CountryCode")]
        public Country? Country { get; set; }

        [Required(ErrorMessage = "Zip is required")]
        [StringLength(10)]
        public string Zip { get; set; }

        [StringLength(25)]
        public string? Phone { get; set; }

        [StringLength(25)]
        public string? Fax { get; set; }

        [StringLength(150)]
        public string? Email { get; set; }

        [StringLength(150)]
        public string? Website { get; set; }

        [StringLength(50)]
        public string? TaxId { get; set; }

        [StringLength(50)]
        public string? VATNo { get; set; }

        [StringLength(500)]
        public string? AdditionalEmails { get; set; }
    }
}
