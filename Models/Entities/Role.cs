using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

using WISSEN.EDA.Data;

namespace WISSEN.EDA.Models.Entities
{
    public class Role : BaseTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // Specify no auto-generation
        [Column(TypeName = "char(4)")]
        public string? Code { get; set; }
        public string? Name { get; set; }
    }
}
