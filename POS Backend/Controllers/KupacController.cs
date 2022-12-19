using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using POS_Backend.DTOs.Kupci;
using POS_Backend.Interfaces;
using POS_Backend.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POS_Backend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class KupacController : ControllerBase
    {

        private readonly ILogger<KupacController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public KupacController(ILogger<KupacController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<ActionResult> AddKupac(CreateKupacDto kupacDto)
        {
            var kupac = new Kupac
            {
                Naziv= kupacDto.Naziv,
                Adresa=kupacDto.Adresa,
                Mjesto=kupacDto.Mjesto,
            };

            _logger.LogInformation("ADDKUPAC initiated");
            try
            {
                _unitOfWork.Kupci.Add(kupac);
                _unitOfWork.Complete();
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Caught");
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetKupacDto>>> GetKupacList()
        {
            _logger.LogInformation("GETKUPACLIST initiated");
            try
            {
                var kupci = await _unitOfWork.Kupci.GetAllKupci();
                return kupci;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Caught");
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteKupac(int id)
        {
            _logger.LogInformation("Delete movie initiated");
            try
            {
                await _unitOfWork.Kupci.DeleteKupac(id);
                return Ok("Completed");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Caught");
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("Update/")]
        public async Task<ActionResult> UpdateKupac(UpdateKupacDto kupacDto)
        {
            _logger.LogInformation("UpdateProizvod initiated");
            try
            {
                await _unitOfWork.Kupci.UpdateKupac(kupacDto);
                return Ok(kupacDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Caught");
                return BadRequest(ex.Message);
            }
        }
    }
}
