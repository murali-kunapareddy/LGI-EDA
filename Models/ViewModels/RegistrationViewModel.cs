using System.ComponentModel.DataAnnotations;

namespace WISSEN.EDA.Models.ViewModels
{
    public class RegistrationViewModel
    {
        [Required]
        [StringLength(50)]
        public string? FirstName { get; set; }

        private string _lastName = string.Empty; // Initialize to avoid null reference
        [Required]
        [StringLength(50)]
        public string LastName
        {
            get => _lastName;
            set => _lastName = value?.ToUpper() ?? string.Empty; // Convert to uppercaseHandle null assignment
        }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string? ConfirmPassword { get; set; }
    }
}
