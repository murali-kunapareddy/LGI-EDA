using WISSEN.EDA.Models.Entities;

namespace WISSEN.EDA.Data
{
    public class UserMenuModel
    {
        public User? User {  get; set; }
        public List<Menu> UserMenus { get; set; }

        //public UserMenuModel(User user)
        //{
        //     //TODO
        //}
    }
}
