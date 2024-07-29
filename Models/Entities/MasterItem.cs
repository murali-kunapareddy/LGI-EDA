using System.ComponentModel.DataAnnotations;
using WISSEN.EDA.Data;

namespace WISSEN.EDA.Models.Entities
{
    public class MasterItem : BaseTable
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Master name is required")]
        [Display(Name = "Master Name")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Master key is required")]
        [StringLength(100)]
        [Display(Name = "Master Key")]
        public string? Key { get; set; }
        [Required(ErrorMessage = "Master value is required")]
        [StringLength(100)]
        [Display(Name = "Key Value")]
        public string? Value { get; set; }
        [Required]
        [StringLength(150)]
        [Display(Name = "Key Notes")]
        public string? Notes { get; set; }
        [Required]
        [Display(Name = "Sequence")]
        public int Sequence { get; set; }
    }
}
