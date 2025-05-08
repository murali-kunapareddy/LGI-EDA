using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;

using WISSEN.EDA.Data;

namespace WISSEN.EDA.Models.Entities
{
    [Index(nameof(Email), IsUnique = true)]
    public class User : BaseTable
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public string? PasswordSalt { get; set; }

        public bool IsApproved { get; set; } = false; // Default to false
    }
}
