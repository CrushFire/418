using Application.Services;
using Core.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace YourNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnamnesController : ControllerBase
    {
        private readonly AnamnesService _anamnesService;
        public AnamnesController(AnamnesService anamnesService)
        {
            _anamnesService = anamnesService;
        }

        // GET api/anamnes/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnamnes(decimal id)
        {
            try
            {
                var anamnesDTO = await _anamnesService.GetAnamnes(id);
                if (anamnesDTO == null)
                {
                    return NotFound($"Anamnes with ID {id} not found.");
                }
                return Ok(anamnesDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET api/anamnes?page=1
        [HttpGet]
        public async Task<IActionResult> GetAllAnamnes([FromQuery] int page)
        {
            if (page <= 0)
            {
                return BadRequest("Page number must be greater than 0.");
            }

            try
            {
                var anamnesisDTO = await _anamnesService.GetAll(page);
                return Ok(anamnesisDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET api/anamnes/patient/{patientId}?page=1
        [HttpGet("patient/{patientId}")]
        public async Task<IActionResult> GetAnamnesisForPatient(int patientId, [FromQuery] int page)
        {
            if (page <= 0)
            {
                return BadRequest("Page number must be greater than 0.");
            }

            try
            {
                var anamnesisDTO = await _anamnesService.GetAnamnesisForPatient(page, patientId);
                return Ok(anamnesisDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST api/anamnes
        [HttpPost]
        public IActionResult CreateAnamnes([FromBody] AnamnesForInDTO anamnesDTO)
        {
            try
            {
                _anamnesService.CreateAnamnes(anamnesDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT api/anamnes/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateAnamnes(decimal id, [FromBody] AnamnesForInDTO anamnesDTO)
        {
                _anamnesService.UpdateAnamnes(anamnesDTO, id);
                return NoContent(); // Successful update, no content to return
            //catch (Exception ex)
            //{
            //    return StatusCode(500, $"Internal server error: {ex.Message}");
            //}
        }

        // DELETE api/anamnes/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteAnamnes(decimal id)
        {
            try
            {
                _anamnesService.DeleteAnamnes(id);
                return NoContent(); // Successfully deleted
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("Count")]
        public IActionResult Count()
        {
            var count = _anamnesService.Count();
            return Ok(count);
        }

        [HttpGet("Count/Patient{idPatient}")]
        public IActionResult CountForPatient(int idPatient)
        {
            var count = _anamnesService.CountForPatient(idPatient);
            return Ok(count);
        }
    }
}
