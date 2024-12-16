using Application.Services;
using Core.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly DoctorService _doctorService;

        public DoctorController(DoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        // Получить информацию о враче по ID
        [HttpGet("{id}")]
        public async Task<ActionResult<DoctorForOutDTO>> GetDoctor(decimal id)
        {
            var doctor = await _doctorService.GetDoctor(id);
            if (doctor == null)
            {
                return NotFound();  // Если врач не найден, возвращаем статус 404
            }
            return Ok(doctor);  // Возвращаем найденного врача
        }

        // Получить список всех врачей с пагинацией
        [HttpGet]
        public async Task<ActionResult<List<DoctorForOutDTO>>> GetAllDoctors(int page = 1)
        {
            var doctors = await _doctorService.GetAllDoctor(page);
            return Ok(doctors);  // Возвращаем список врачей
        }

        // Создать нового врача
        [HttpPost]
        public IActionResult CreateDoctor([FromBody] DoctorWithOutIdDTO doctorDTO)
        {
            if (doctorDTO == null)
            {
                return BadRequest("Invalid doctor data");  // Возвращаем ошибку 400, если данные некорректны
            }

            // Создаем нового врача через сервис
            _doctorService.CreateDoctor(doctorDTO);
            return Ok();  // Возвращаем статус 201 с ссылкой на новый ресурс
        }

        // Обновить данные врача
        [HttpPut("{id}")]
        public IActionResult UpdateDoctor(decimal id, [FromBody] DoctorWithOutIdDTO doctorDTO)
        {
            if (doctorDTO == null)
            {
                return BadRequest("Invalid doctor data");  // Возвращаем ошибку 400, если данные некорректны
            }

            // Обновляем данные врача через сервис
            _doctorService.UpdateDoctor(doctorDTO, id);
            return NoContent();  // Возвращаем статус 204, что ресурс обновлен
        }

        // Удалить врача
        [HttpDelete("{id}")]
        public IActionResult DeleteDoctor(decimal id)
        {
            _doctorService.DeleteDoctor(id);
            return NoContent();  // Возвращаем статус 204, что ресурс удален
        }

        [HttpGet("Count")]
        public IActionResult GetCount()
        {
            var count = _doctorService.Count();
            return Ok(count);
        }
    }
}
