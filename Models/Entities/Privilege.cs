using System.ComponentModel.DataAnnotations;

using WISSEN.EDA.Data;

namespace WISSEN.EDA.Models.Entities
{
    public class Privilege:BaseTable
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Controller { get; set; }
        public string? Action { get; set; }
    }
}
