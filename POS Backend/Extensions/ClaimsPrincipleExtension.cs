using System.Security.Claims;

namespace POS_Backend.Extensions
{
    public static class ClaimsPrincipleExtension
    {
        public static string GetUsername(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.Name);
        }
        public static int GetUserId(this ClaimsPrincipal user) { return int.Parse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value); }
    }
}
