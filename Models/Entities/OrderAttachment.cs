using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WISSEN.EDA.Data;

namespace WISSEN.EDA.Models.Entities
{
    public class OrderAttachment: BaseTable
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(150)]
        public string? FileName { get; set; }

        [Required]
        [StringLength(100)]
        public string? FileType { get; set; }
        
        public int FileSize { get; set; }

        [StringLength(40)]
        public string? FileHash { get; set; }

        [Required]
        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public Order? Order { get; set; }
    }
}
