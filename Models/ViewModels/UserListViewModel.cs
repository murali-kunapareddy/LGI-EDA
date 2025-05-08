using System.ComponentModel.DataAnnotations.Schema;

using WISSEN.EDA.Models.Entities;

namespace WISSEN.EDA.Models.ViewModels
{
    public class UserListViewModel
    {
        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public string? Email { get; set; }
        public string? Designation { get; set; }
        public string? Role { get; set; }
        public string? CompanyName { get; set; }
    }
}
