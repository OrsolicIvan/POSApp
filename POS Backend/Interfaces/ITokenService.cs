using POS_Backend.Models;
using System.Threading.Tasks;

namespace POS_Backend.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(AppUser user);
    }
}
