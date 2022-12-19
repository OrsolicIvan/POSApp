using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace POS_Backend.Models
{
    public class AppUser : IdentityUser<int>
    {
        public List<AppUserRole> UserRoles { get; set; }
    }
}
