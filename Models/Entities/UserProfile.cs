using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using WISSEN.EDA.Data;

namespace WISSEN.EDA.Models.Entities
{
    /// <summary>
    /// Represents a user profile with personal and professional details.
    /// </summary>
    public class UserProfile: BaseTable
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        [RegularExpression("^[MFO]$", ErrorMessage = "Gender must be 'M' for Male, 'F' for Female, or 'O' for Other")]
        [Column(TypeName = "char(1)")]
        public string? Gender { get; set; }
        public string? ContactNo { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? JoiningDate { get; set; }
        public string? Designation { get; set; }
        public string? Department { get; set; }
        public string? ProfilePhoto { get; set; }
        public string? AboutMe { get; set; }
        public int? ManagerId { get; set; } // FK to Manager, made nullable
        [ForeignKey("ManagerId")]
        public User? Manager { get; set; } 
        public int? CompanyCode { get; set; } // FK to Company, made nullable
        [ForeignKey("CompanyCode")]
        public Company? Company { get; set; }
        public int? AddressId { get; set; } // FK to Address, made nullable
        [ForeignKey("AddressId")]
        public Address? Address { get; set; }
        public int UserId { get; set; } // FK to User,  Not Nullable
        [ForeignKey("UserId")]
        public User? User { get; set; }
    }
}
