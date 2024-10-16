using System.ComponentModel.DataAnnotations;
using WISSEN.EDA.Data;

namespace WISSEN.EDA.Models.Entities
{
    public class Country : BaseTable
    {
        [Key]
        [StringLength(2)]
        public string? Code { get; set; }
        [Required(ErrorMessage = "Country Name is required")]
        [StringLength(100)]
        public string? Name { get; set; }

        //public ICollection<Company>? Companies { get; set;}
    }
}
