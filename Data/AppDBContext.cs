using Microsoft.EntityFrameworkCore;
using WISSEN.EDA.Models.Entities;

namespace WISSEN.EDA.Data
{
    public class AppDBContext: DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options):base(options)
        {
            // comes something
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Plant> Plants { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Authentication> Authenticaions { get; set; }
        public DbSet<UserPrivilege> UserPrivileges { get; set; }
        public DbSet<ConfigurationItem> ConfigurationItems { get; set; }
        public DbSet<MasterItem> MasterItems { get; set; }
    }
}
