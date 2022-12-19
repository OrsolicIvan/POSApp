using Microsoft.AspNetCore.Authorization;   
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using POS_Backend.Interfaces;
using System.Threading.Tasks;

namespace POS_Backend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class JedinicaController : ControllerBase
    {
        private readonly ILogger<JedinicaController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public JedinicaController(ILogger<JedinicaController> logger, IUnitOfWork unitOfWork) 
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<ActionResult> GetJedinice()
        {
            _logger.LogInformation("GetJedinice initiated");
            try
            {
                var racuni = await _unitOfWork.Racuni.GetJedinice();
                return Ok(racuni);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Exception Caught");
                return BadRequest(ex.Message);
            }
        }
    }
}
