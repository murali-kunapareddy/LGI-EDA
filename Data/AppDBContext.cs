using Microsoft.EntityFrameworkCore;

using WISSEN.EDA.Models.Entities;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WISSEN.EDA.Data
{
    public class AppDBContext(DbContextOptions<AppDBContext> options) : DbContext(options)
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Authentication> Authenticaions { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ConfigurationItem> ConfigurationItems { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAttachment> CustomerAttachments { get; set; }
        public DbSet<CustomerPaperwork> CustomerPaperworks { get; set; }
        public DbSet<MasterItem> MasterItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderAttachment> OrderAttachments { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Privilege> Privileges { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RolePrivilege> RolePrivileges { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships and constraints

            modelBuilder.Entity<UserRole>()
               .HasOne(ur => ur.User)
               .WithMany() 
               .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany()
                .HasForeignKey(ur => ur.RoleCode);

            modelBuilder.Entity<RolePrivilege>()
                .HasOne(rp => rp.Role)
                .WithMany()
                .HasForeignKey(rp => rp.RoleCode);

            modelBuilder.Entity<RolePrivilege>()
                .HasOne(rp => rp.Privilege)
                .WithMany()
            .HasForeignKey(rp => rp.PrivilegeId);

            modelBuilder.Entity<UserProfile>()
                .HasOne(p => p.User)
                .WithOne() // One-to-one relationship
                .HasForeignKey<UserProfile>(p => p.UserId); // Profile has the FK

            // Set Company Code as PK, and not auto generated.
            modelBuilder.Entity<Company>()
                .HasKey(c => c.Code);
            
            // Set Country Code as PK, and not auto generated.
            modelBuilder.Entity<Country>()
                .HasKey(c => c.Code);
        }

    }
}
