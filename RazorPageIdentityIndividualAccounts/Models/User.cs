using Microsoft.AspNetCore.Identity;
using System;

namespace RazorPageIdentityIndividualAccounts.Models
{
    public class User : IdentityUser
    {
        [PersonalData]
        public string Address { get; set; }
        [PersonalData]
        public DateTime DOB { get; set; }
    }
}
