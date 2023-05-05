using Domain.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data
{
    public class AltayeeDBContext : IdentityDbContext<ApplicationUser>
    {
        public AltayeeDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Products> Products { get; set; }

        public DbSet<Brands> Brands { get; set; }

        public DbSet<Images> Images { get; set; }

        public DbSet<Relateds> Relateds { get; set; }

        public DbSet<Types> Types { get; set; }

        public DbSet<ContactUs> ContactUs { get; set; }

        public DbSet<Orders> Orders { get; set; }

        public DbSet<OrderDetails> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // any unique string id
            const string ADMIN_ID = "a18be9c0";
            const string ADMIN_ROLE_ID = "ad376a8f";

            const string EDITOR_ID = "a50ze710";
            const string EDITOR_ROLE_ID = "bd586a8f";

            // create an Admin role
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = ADMIN_ROLE_ID,
                Name = "Admin",
                NormalizedName = "Admin"
            }, new IdentityRole
            {
                Id = EDITOR_ROLE_ID,
                Name = "Editor",
                NormalizedName = "Editor"
            });

            // create a User
            var hasher = new PasswordHasher<ApplicationUser>();
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = ADMIN_ID,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "admin@gmail.com",
                NormalizedEmail = "admin@gmail.com",
                EmailConfirmed = false,
                PasswordHash = hasher.HashPassword(null, "P@ssw0rd@2023"),
                SecurityStamp = string.Empty
            },
            new ApplicationUser
            {
                Id = EDITOR_ID,
                UserName = "Administrator",
                NormalizedUserName = "Administrator",
                Email = "Administrator@gmail.com",
                NormalizedEmail = "Administrator@gmail.com",
                EmailConfirmed = false,
                PasswordHash = hasher.HashPassword(null, "P@ssw0rd@2023"),
                SecurityStamp = string.Empty
            });

            // assign that user to the admin role
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ADMIN_ROLE_ID,
                UserId = ADMIN_ID
            },
            new IdentityUserRole<string>
            {
                RoleId = EDITOR_ROLE_ID,
                UserId = EDITOR_ID
            });
        }
    }
}
