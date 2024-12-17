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
    public class HumanController : ControllerBase
    {
        private readonly HumanService _humanService;

        public HumanController(HumanService humanService)
        {
            _humanService = humanService;
        }

        // GET api/human/admin?page=1
        [HttpGet("admin")]
        public async Task<IActionResult> GetAllAdmins()
        {
            try
            {
                var humans = await _humanService.GetAllAdmin();

                return Ok(humans);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST api/human/create
        [HttpPost("create")]
        public IActionResult CreateHuman([FromBody] HumanWithOutIdDTO humanDTO)
        {
            if (humanDTO == null)
            {
                return BadRequest("Invalid human data.");
            }

            try
            {
                _humanService.CreateAdmin(humanDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE api/human/delete/{id}
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteAdmin(decimal id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid id.");
            }

            try
            {
                _humanService.DeleteAdmin(id);
                return Ok(); // 204 No Content
            }
            catch (Exception ex)
            {
                return NotFound($"Human with ID {id} not found. Error: {ex.Message}");
            }
        }

        [HttpGet("Count")]
        public IActionResult Count()
        {
            var count = _humanService.Count();
            return Ok(count);
        }
    }
}
