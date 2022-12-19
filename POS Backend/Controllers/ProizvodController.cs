using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using POS_Backend.DTOs.Proizvod;
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
    public class ProizvodController : ControllerBase
    {
        private readonly ILogger<ProizvodController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public ProizvodController(ILogger<ProizvodController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<ActionResult> AddProizvod(CreateProizvodDto proizvodDto)
        {
            _logger.LogInformation("ADDPROIZVOD initiated");
            try
            {
                await _unitOfWork.Proizvodi.CreateProizvod(proizvodDto);
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
        public async Task<ActionResult<IEnumerable<GetProizvodDto>>> GetProizvodList()
        {
            _logger.LogInformation("GETPROIZVODLIST initiated");
            try
            {
                var Movies = await _unitOfWork.Proizvodi.GetAllProizvodi();
                return Movies;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Caught");
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteProizvod(int id)
        {
            _logger.LogInformation("Delete proizvod initiated");
            try
            {
                await _unitOfWork.Proizvodi.DeleteProizvod(id);
                return Ok("Completed");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Caught");
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<ActionResult> UpdateProizvod(UpdateProizvodDto proizvodDto)
        {
            _logger.LogInformation("UpdateProizvod initiated");
            try
            {
                await _unitOfWork.Proizvodi.UpdateProizvod(proizvodDto);
                return Ok(proizvodDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Caught");
                return BadRequest(ex.Message);
            }
        }

        

    }
}
