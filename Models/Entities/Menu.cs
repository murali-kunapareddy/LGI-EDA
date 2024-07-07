using System.ComponentModel.DataAnnotations;
using WISSEN.EDA.Data;

namespace WISSEN.EDA.Models.Entities
{
    public class Menu : BaseTable
    {
        [Key]
        [StringLength(10)]
        public string? Code { get; set; }
        [Required(ErrorMessage ="Menu name is required")]
        [StringLength(25)]
        public string? Name { get; set; }
        [Required]
        [StringLength(10)]
        public string? Parent { get; set; }
    }
}
