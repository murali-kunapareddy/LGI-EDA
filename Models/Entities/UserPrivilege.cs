using System.ComponentModel.DataAnnotations;
using WISSEN.EDA.Data;
using static WISSEN.EDA.Data.Enums;

namespace WISSEN.EDA.Models.Entities
{
    public class UserPrivilege : BaseTable
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "User is required")]
        [StringLength(100)]
        public User? User { get; set; }
        [Required(ErrorMessage = "Role is required")]
        [StringLength(25)]
        public string? Role { get; set; }
        [Required(ErrorMessage ="Application is required")]
        public AppCode Application { get; set; }
        //[Required(ErrorMessage = "Company is required")]
        //public Company? Company { get; set; }
        //[Required(ErrorMessage = "Plant is required")]
        //public Plant? Plant { get; set; }
        [Required(ErrorMessage = "Menu is required")]
        public Menu? Menu { get; set; }
        public bool Create { get; set; } = false;
        public bool Read { get; set; } = false;
        public bool Update { get; set; } = false;
        public bool Delete { get; set; } = false;

    }
}
