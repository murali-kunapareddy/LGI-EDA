using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WISSEN.EDA.Data;

namespace WISSEN.EDA.Models.Entities
{
    public class Product : BaseTable
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(100, ErrorMessage = "Product code is required")]
        [Display(Name = "Product Code")]
        public string? Code { get; set; }
        
        [Required(ErrorMessage = "Product name is required")]
        [StringLength(100)]
        [Display(Name = "Product Name")]
        public string? Name { get; set; }
        
        [Required(ErrorMessage = "Company is required")]
        [Display(Name = "Company")]
        public int CompanyCode { get; set; }

        [ForeignKey("CompanyCode")]
        public virtual Company? Company { get; set; }
    }
}
