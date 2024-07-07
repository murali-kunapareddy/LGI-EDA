using System.ComponentModel.DataAnnotations;
using WISSEN.EDA.Data;

namespace WISSEN.EDA.Models.Entities
{
    public class Authorization: BaseTable
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage ="User is required")]
        public User? User { get; set; }
        [Required(ErrorMessage = "Menu is required")]
        public Menu? Menu { get; set; }
        [Required]
        [StringLength(3,MinimumLength =3,ErrorMessage ="Permission must have 3 digits")]
        [Range(0,777,ErrorMessage ="Should be between 000 to 777")]
        public string? PermissionCode { get; set; }
    }
}
