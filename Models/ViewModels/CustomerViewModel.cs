using WISSEN.EDA.Data;
using WISSEN.EDA.Models.Entities;

namespace WISSEN.EDA.Models.ViewModels
{
    public class CustomerViewModel
    {
        public Customer? Customer { get; set; } = new Customer();
        public List<CustomerPaperwork> Paperworks { get; set; } = new();
        public List<MasterItem>? ConsigneeTypes { get; set; }
        public List<MasterItem>? PaymentTerms { get; set; }
        public List<MasterItem>? Incoterms { get; set; }
        //public List<Country>? Countries { get; set; }
    }
}
