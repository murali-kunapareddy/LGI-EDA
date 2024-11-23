using WISSEN.EDA.Models.Entities;

namespace WISSEN.EDA.Models.ViewModels
{
	public class PaperworksViewModel
	{
		public int Id { get; set; }
		public string? PaperworksId { get; set; }
		public string? PaperworksName { get; set; }
		public bool IsRequired { get; set; }
		public int OriginalQuantity { get; set; }
		public int CopyQuantity { get; set; }

		public int CustomerId { get; set; }
    }
}
