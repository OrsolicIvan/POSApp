using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace POS_Backend.Models
{
    public class AppRole : IdentityRole<int>
    {
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}
