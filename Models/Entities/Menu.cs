using System.ComponentModel.DataAnnotations;
using WISSEN.EDA.Data;
using static WISSEN.EDA.Data.Enums;

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
        [Required(ErrorMessage = "Controller is required")]
        [StringLength(50)]
        public string? Controller { get; set; }
        [Required(ErrorMessage = "Action is required")]
        [StringLength(50)]
        public string? Action { get; set; }
        [Required(ErrorMessage ="Sequence is required")]
        public int Sequence { get; set; }
        [Required]
        [StringLength(2)]
        public AppCode AppCode { get; set; }
        [Required]
        [StringLength(10)]
        public string? Parent { get; set; }
    }
}
