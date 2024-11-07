using System.ComponentModel.DataAnnotations;
using WISSEN.EDA.Data;

namespace WISSEN.EDA.Models.Entities
{
    public class ConfigurationItem : BaseTable
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(100, ErrorMessage ="Configuration name is required")]
        [Display(Name = "Configuration Name")]
        public string? Name { get; set; }
        
        [Required]
        [StringLength(100, ErrorMessage = "Configuration key is required")]
        [Display(Name = "Configuration Key")]
        public string? Key { get; set; }
        
        [Required]
        [StringLength(100, ErrorMessage = "Configuration value is required")]
        [Display(Name = "Configuration Value")]
        public string? Value { get; set; }
        
        [Required]
        [Display(Name = "Sequence")]
        public int Sequence{ get; set; }
    }
}
