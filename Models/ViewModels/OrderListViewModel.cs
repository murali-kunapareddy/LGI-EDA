using WISSEN.EDA.Models.Entities;

namespace WISSEN.EDA.Models.ViewModels
{
	public class OrderListViewModel
	{
		public int Id { get; set; }
		public string? CustomerPONo { get; set; }
		public string? ContractNo { get; set; }
		public string? ShipToName { get; set; }
		public string? BillToName { get; set; }
		public DateOnly OrderDate { get; set; }
		public DateOnly SubmitDate { get; set; }
		public string? Status { get; set; }
		public bool IsActive { get; set; }
	}
}
