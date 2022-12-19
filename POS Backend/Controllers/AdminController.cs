using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using POS_Backend.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace POS_Backend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<AdminController> _logger;
        public AdminController(UserManager<AppUser> userManager, ILogger<AdminController> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        [HttpGet("users-with-roles")]
        public async Task<ActionResult<AppUser>> GetUsersWithRoles()
        {



            _logger.LogInformation("GetUsersWithRoles initiated");
            try
            {
                var users = await _userManager.Users
                .Include(r => r.UserRoles)
                .ThenInclude(r => r.Role)
                .OrderBy(u => u.UserName)
                .Select(u => new { u.Id, Username = u.UserName, Roles = u.UserRoles.Select(r => r.Role.Name).ToList() })
                .ToListAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Caught");
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("edit-user-roles/{username}")]
        public async Task<ActionResult> EditRoles(string username, [FromQuery] string roles)
        {



            _logger.LogInformation("EditUserRoles initiated");
            try
            {
                var selectedRoles = roles.Split(",").ToArray();

                var user = await _userManager.FindByNameAsync(username);

                if (user == null) return NotFound("Could not find user");

                var userRoles = await _userManager.GetRolesAsync(user);

                var result = await _userManager.AddToRolesAsync(user, selectedRoles.Except(userRoles));
                if (!result.Succeeded) return BadRequest("Failed to add to roles");

                result = await _userManager.RemoveFromRolesAsync(user, userRoles.Except(selectedRoles));
                if (!result.Succeeded) return BadRequest("Failed to remove from roles");

                return Ok(await _userManager.GetRolesAsync(user));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Caught");
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete-user/{username}")]
        public async Task<ActionResult> DeleteUser(string username)
        {

            _logger.LogInformation("DeleteUser initiated");
            try
            {
                var user = await _userManager.FindByNameAsync(username);
                if (user == null) return NotFound();
                await _userManager.DeleteAsync(user);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Caught");
                return BadRequest(ex.Message);
            }
        }
    }
}

