using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RazorPageIdentityIndividualAccounts.Models;
using System.Linq;
using System;
using System.Net;

namespace RazorPageIdentityIndividualAccounts.Data
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(ApplicationDbContext db,
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public void Initialize()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception)
            {

            }

            if (!_roleManager.RoleExistsAsync(ApplicationRoles.Admin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(ApplicationRoles.Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(ApplicationRoles.Employee)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(ApplicationRoles.Customer)).GetAwaiter().GetResult();

                _userManager.CreateAsync(new User
                {
                    UserName = "admin@master.com",
                    Email = "admin@master.com",
                    EmailConfirmed = true,
                    Address = "Hn",
                    DOB = DateTime.Now,
                }, "Admin123*").GetAwaiter().GetResult();

                User user = _db.User.FirstOrDefault(u => u.Email == "admin@master.com");

                _userManager.AddToRoleAsync(user, ApplicationRoles.Admin).GetAwaiter().GetResult();
            }
        }
    }
}
