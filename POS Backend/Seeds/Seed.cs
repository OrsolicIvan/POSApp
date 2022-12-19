using POS_Backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace POS_Backend.Seeds
{
    public class Seed
    {
        public static async Task SeedUsers(Context _context,UserManager<AppUser> customerManager,
            RoleManager<AppRole> roleManager)
        {
            if (await customerManager.Users.AnyAsync()) return;

            var userData = await System.IO.File.ReadAllTextAsync("Seeds/UserSeedData.json");
            var users = JsonSerializer.Deserialize<List<AppUser>>(userData);
            var JediniceData = await System.IO.File.ReadAllTextAsync("Seeds/JediniceMjereSeedData.json");
            var jedinice = JsonSerializer.Deserialize<List<JedinicaMjere>>(JediniceData);
            var ProizvodiData = await System.IO.File.ReadAllTextAsync("Seeds/ProizvodiSeedData.json");
            var proizvodi = JsonSerializer.Deserialize<List<Proizvod>>(ProizvodiData);
            if (users == null) return;
            if (jedinice == null) return;
            var roles = new List<AppRole>
            {
                new AppRole{Name= "SuperAdmin"},
                new AppRole{Name= "Admin"},
            };

            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }

            foreach (var user in users)
            {


                user.UserName = user.UserName.ToLower();


                await customerManager.CreateAsync(user, "Kolikoje3");
                await customerManager.AddToRoleAsync(user, "Admin");
            }
            foreach (var jedinica in jedinice)
            {
                await _context.JediniceMjere.AddAsync(jedinica);
            }
            foreach (var proizvod in proizvodi)
            {
                proizvod.JedinicaMjere = await _context.JediniceMjere.FirstOrDefaultAsync(x => x.Id == proizvod.JedinicaId);
                await _context.Proizvodi.AddAsync(proizvod);
            }
            var admin = new AppUser
            {
                UserName = "admin"
            };

            await customerManager.CreateAsync(admin, "Kolikoje3");
            await customerManager.AddToRolesAsync(admin, new[] { "SuperAdmin" });

        }
    }
}
