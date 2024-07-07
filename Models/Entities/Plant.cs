using System.ComponentModel.DataAnnotations;
using WISSEN.EDA.Data;

namespace WISSEN.EDA.Models.Entities
{
    public class Plant: BaseTable
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Plant Code is required")]
        [StringLength(5)]
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
        [Required(ErrorMessage = "Country is required")]
        public Country? Country { get; set; }
        [Required(ErrorMessage = "Zip is required")]
        [StringLength(6)]
        public string? zip { get; set; }
        [StringLength(15)]
        public string? Phone { get; set; }
        [Required]
        public Company? Company { get; set; }
    }
}
