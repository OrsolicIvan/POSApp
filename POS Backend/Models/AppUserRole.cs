using Microsoft.AspNetCore.Identity;

namespace POS_Backend.Models
{
    public class AppUserRole : IdentityUserRole<int>
    {

        public AppUser AppUser { get; set; }
        public AppRole Role { get; set; }
    }
}
