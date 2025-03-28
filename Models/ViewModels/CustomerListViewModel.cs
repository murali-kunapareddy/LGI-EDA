using WISSEN.EDA.Models.Entities;

namespace WISSEN.EDA.Models.ViewModels
{
	public class CustomerListViewModel
	{
		public int Id { get; set; }
		public string? BillToNo { get; set; }
		public string? BillToName { get; set; }
		public string? ShipToNo { get; set; }
		public string? ShipToName { get; set; }
		public int CompanyCode { get; set; }
		public string? CompanyName { get; set; }
		public bool IsActive { get; set; }
	}
}
