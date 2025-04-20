using Microsoft.EntityFrameworkCore;

using WISSEN.EDA.Models.Entities;

namespace WISSEN.EDA.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            // comes something
        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Authentication> Authenticaions { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ConfigurationItem> ConfigurationItems { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAttachment> CustomerAttachments { get; set; }
        public DbSet<CustomerPaperwork> CustomerPaperworks { get; set; }
        public DbSet<MasterItem> MasterItems { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderAttachment> OrderAttachments { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        //public DbSet<UserPrivilege> UserPrivileges { get; set; }

    }
}
