using WISSEN.EDA.Models.Entities;

namespace WISSEN.EDA.Models.ViewModels
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        public User? User { get; set; } = new User();
        public UserProfile? UserProfile { get; set; } = new UserProfile();
        public Role? UserRole { get; set; } = new Role();
    }
}
