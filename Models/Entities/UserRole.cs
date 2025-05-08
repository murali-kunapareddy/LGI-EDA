using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using WISSEN.EDA.Data;

namespace WISSEN.EDA.Models.Entities
{
    public class UserRole : BaseTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-increment primary key
        public int Id { get; set; }

        [Required] // Ensure UserId is required
        public int UserId { get; set; } // Foreign key to User table
        [ForeignKey("UserId")]
        public User? User { get; set; } // Navigation property

        [Required] // Ensure RoleCode is required
        [Column(TypeName = "char(4)")]
        public string? RoleCode { get; set; } // Foreign key to Role table
        [ForeignKey("RoleCode")]
        public Role? Role { get; set; } // Navigation property
    }
}

