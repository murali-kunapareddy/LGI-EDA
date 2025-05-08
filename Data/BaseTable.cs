using System.ComponentModel.DataAnnotations;
using WISSEN.EDA.Models.Entities;

namespace WISSEN.EDA.Data
{
    public class BaseTable
    {
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public string? CreatedBy { get; set; } // User Email
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public string? ModifiedBy { get; set; } // User Email
        public DateTime? ModifiedOn { get; set; }
    }
}
