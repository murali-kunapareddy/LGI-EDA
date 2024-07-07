using System.ComponentModel.DataAnnotations;
using WISSEN.EDA.Data;

namespace WISSEN.EDA.Models.Entities
{
    public class Authentication : BaseTable
    {
        [Key]
        [StringLength(100)]
        public string? Email { get; set; }
        [Required]
        [StringLength (40)]
        public string? PasswordHash { get; set; }
        [Required]
        [StringLength(40)]
        public string? PasswordSalt { get; set; }
        [Required]
        public int FailedAttempts { get; set; }
        [Required]
        public DateTime LastSuccessfulAttemptOn { get; set; }
        public DateTime LastFailedAttemptOn { get; set; }

    }
}
