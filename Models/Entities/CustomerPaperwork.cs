using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WISSEN.EDA.Data;

namespace WISSEN.EDA.Models.Entities
{
    public class CustomerPaperwork: BaseTable
    {
        [Key]
        public int Id { get; set; }

        [Required] 
        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer? Customer { get; set; }

        [Required]
        public int PaperworkId { get; set; }

        [ForeignKey("PaperworkId")]
        public virtual MasterItem? Paperwork { get; set; }

        public int OriginalQuantity { get; set; }

        public int CopyQuantity { get; set; }
    }
}
