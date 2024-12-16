using Application.Services;
using Core.DTO;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace YourNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WardController : ControllerBase
    {
        private readonly WardService _wardService;

        // Конструктор, который инжектирует зависимость WardService
        public WardController(WardService wardService)
        {
            _wardService = wardService;
        }

        // GET: api/ward?page=1
        [HttpGet]
        public async Task<IActionResult> GetAll(int page)
        {
            try
            {
                // Получаем список отделов с помощью сервиса
                var wards = await _wardService.GetAll(page);
                return Ok(wards); // Возвращаем 200 OK с данными
            }
            catch (Exception ex)
            {
                // В случае ошибки возвращаем ошибку с сообщением
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/ward
        [HttpPost]
        public IActionResult AddWard([FromBody] WardForInOutDTO wardDTO)
        {
                _wardService.AddWard(wardDTO); // Добавляем новый отдел через сервис
                return CreatedAtAction(nameof(GetAll), new { page = 1 }, wardDTO); // Возвращаем статус 201 Created
        }

        // DELETE: api/ward/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteWard(int id)
        {

                _wardService.DeleteWard(id); // Удаляем отдел через сервис
                return NoContent(); // Возвращаем статус 204 No Content
        }
    }
}
