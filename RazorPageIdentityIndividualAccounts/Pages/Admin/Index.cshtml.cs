using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPageIdentityIndividualAccounts.Models;
using System.Diagnostics.CodeAnalysis;

namespace RazorPageIdentityIndividualAccounts.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<User> _userManager;

        public IndexModel(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async void OnGet()
        {
            var user = await _userManager.GetUserAsync(User);
            var role = _userManager.GetRolesAsync(user);
            if (User.IsInRole(ApplicationRoles.Admin))
            {
                ViewData["Data"] = "Admin";
            }
            else if (User.IsInRole(ApplicationRoles.Employee))
            {
                ViewData["Data"] = "Employee";
            }
            else if (User.IsInRole(ApplicationRoles.Customer))
            {
                ViewData["Data"] = "Customer";
            }
            else
            {
                ViewData["Data"] = "Not found role";
            }
        }
    }
}
