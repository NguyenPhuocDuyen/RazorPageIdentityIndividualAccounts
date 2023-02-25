using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RazorPageIdentityIndividualAccounts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RazorPageIdentityIndividualAccounts.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { set; get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<IdentityRole>().HasData(
            //    new IdentityRole { Name = ApplicationRoles.Admin, NormalizedName = ApplicationRoles.Admin.ToUpper() },
            //    new IdentityRole { Name = ApplicationRoles.Customer, NormalizedName = ApplicationRoles.Customer.ToUpper() },
            //    new IdentityRole { Name = ApplicationRoles.Employee, NormalizedName = ApplicationRoles.Employee.ToUpper() }
            //);

            modelBuilder.Entity<IdentityUser>().ToTable("Users").Property(p => p.Id).HasColumnName("Id");
            modelBuilder.Entity<User>().ToTable("Users").Property(p => p.Id).HasColumnName("Id");
        }
    }
}
