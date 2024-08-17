using System.ComponentModel.DataAnnotations;

namespace WISSEN.EDA.Models.ViewModels
{
    public class DdlViewModel
    {
        [Display(Name = "Value Field")]
        public string? Key { get; set; }
        [Display(Name = "Display Field")]
        public string? Value { get; set; }
    }
}
