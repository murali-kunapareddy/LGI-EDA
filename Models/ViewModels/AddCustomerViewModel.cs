using WISSEN.EDA.Data;
using WISSEN.EDA.Models.Entities;

namespace WISSEN.EDA.Models.ViewModels
{
	public class AddCustomerViewModel: BaseTable
	{
		public Customer? Customer { get; set; }
        public List<MasterItem>? Paperworks { get; set; }
        public List<MasterItem>? ConsigneeTypes { get; set; }
        public List<MasterItem>? PaymentTerms { get; set; }
        public List<MasterItem>? Incoterms { get; set; }
    }
}
