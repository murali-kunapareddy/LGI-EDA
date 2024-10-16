using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WISSEN.EDA.Data;

namespace WISSEN.EDA.Models.Entities
{
    public class Plant: BaseTable
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Plant Code is required")]
        public int Code { get; set; }
        [Required(ErrorMessage = "Plant Name is required")]
        [StringLength(50)]
        public string? Name { get; set; }
        [Required(ErrorMessage = "City is required")]
        [StringLength(50)]
        public string? City { get; set; }
        [Required(ErrorMessage = "State is required")]
        [StringLength(50)]
        public string? State { get; set; }        
        [Required(ErrorMessage = "Zip is required")]
        [StringLength(6)]
        public string? zip { get; set; }
        [StringLength(15)]
        public string? Phone { get; set; }
        [Required(ErrorMessage = "Company is required")]
        public int CompanyCode { get; set; }
        [ForeignKey("CompanyCode")]
        public Company? Company { get; set; }
    }
}
