using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using POS_Backend.DTOs.Racun.Creating;
using POS_Backend.Interfaces;
using System;
using System.Threading.Tasks;

namespace POS_Backend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RacunController : ControllerBase
    {

        private readonly ILogger<RacunController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public RacunController(ILogger<RacunController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        [HttpPost]
        public async Task<ActionResult> CreateRacun(ZaglavljeRacunaDto racunDto)
        {
            _logger.LogInformation("CREATERACUN initiated");
            try
            {
               await _unitOfWork.Racuni.CreateRacun(racunDto);
                _unitOfWork.Complete();
                return Ok();
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Exception Caught");
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<ActionResult> GetRacunList()
        {
            _logger.LogInformation("GETRACUNLIST initiated");
            try
            {
                var racuni = await _unitOfWork.Racuni.GetAllZaglavlja();
                return Ok(racuni);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Exception Caught");
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteRacun(int id)
        {
            _logger.LogInformation("DELETERACUN initiated");
            try
            {
                await _unitOfWork.Racuni.DeleteRacun(id);
                return Ok("Completed");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Caught");
                return BadRequest(ex.Message);
            }
        }

    }
}
