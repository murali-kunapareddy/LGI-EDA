using System.ComponentModel.DataAnnotations;
using WISSEN.EDA.Data;

namespace WISSEN.EDA.Models.Entities
{
    public class User : BaseTable
    {
        [Key]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email")]
        [StringLength(100)]
        public string? Email { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50)]
        public string? FirstName { get; set; }
        [StringLength(50)]
        public string? LastName { get; set; }
        [StringLength(15)]
        public string? Mobile { get; set; }
        [Required]
        public Company? Company { get; set; }
    }
}
