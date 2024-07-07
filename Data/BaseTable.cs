using System.ComponentModel.DataAnnotations;
using WISSEN.EDA.Models.Entities;

namespace WISSEN.EDA.Data
{
    public class BaseTable
    {
        [Required]
        public bool IsActive { get; set; } = true;
        [Required]
        public bool IsDeleted { get; set; } = false;
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email")]
        public string? CreatedBy { get; set; }
        [Required]
        public DateTime? CreatedOn { get; set; } = DateTime.Now;
        public string? ModifiedBy { get; set; } = null;
        public DateTime? ModifiedOn { get; set; } = null;
    }
}
