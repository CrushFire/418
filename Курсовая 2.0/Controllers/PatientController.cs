using Application.Services;
using Core.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Курсовая_2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
            private readonly PatientService _patientService;

            public PatientController(PatientService patientService)
            {
                _patientService = patientService;
            }

            /// <summary>
            /// Получение данных о пациенте по ID
            /// </summary>
            /// <param name="id">Идентификатор пациента</param>
            /// <returns>Данные пациента</returns>
            [HttpGet("{id}")]
            public async Task<ActionResult<PatientForOutDTO>> GetPatient(decimal id)
            {
                var patient = await _patientService.GetPatient(id);
                if (patient == null)
                {
                    return NotFound();
                }
                return Ok(patient);
            }

            /// <summary>
            /// Получение всех пациентов
            /// </summary>
            /// <returns>Список пациентов</returns>
            [HttpGet]
            public async Task<ActionResult<List<PatientForOutDTO>>> GetAllPatients(int page)
            {
                var patients = await _patientService.GetAll(page);
                return Ok(patients);
            }

            /// <summary>
            /// Создание нового пациента
            /// </summary>
            /// <param name="patientDTO">Данные пациента</param>
            [HttpPost]
            public IActionResult CreatePatient([FromBody] PatientWithOutIdDTO patientDTO)
            {
                if (patientDTO == null)
                {
                    return BadRequest();
                }

                _patientService.CreatePatient(patientDTO);
                return Ok();
            }

            /// <summary>
            /// Обновление данных пациента
            /// </summary>
            /// <param name="id">Идентификатор пациента</param>
            /// <param name="patientDTO">Обновленные данные пациента</param>
            [HttpPut("{id}")]
            public IActionResult UpdatePatient(decimal id, [FromBody] PatientWithOutIdDTO patientDTO)
            {
                if (patientDTO == null)
                {
                    return BadRequest();
                }

                _patientService.UpdatePatient(patientDTO, id);
                return NoContent(); // Возвращаем 204, так как обновление прошло успешно
            }

            /// <summary>
            /// Удаление пациента
            /// </summary>
            /// <param name="id">Идентификатор пациента</param>
            [HttpDelete("{id}")]
            public IActionResult DeletePatient(decimal id)
            {
                _patientService.DeletePatient(id);
                return NoContent(); // Возвращаем 204, так как удаление прошло успешно
            }

            /// <summary>
            /// Обновление места пациента
            /// </summary>
            /// <param name="id">Идентификатор пациента</param>
            /// <param name="newPlace">Новая информация о месте пациента</param>
            [HttpPut("{id}/place")]
            public IActionResult UpdatePatientPlace(decimal id, [FromBody] NewPlacePatientDTO newPlace)
            {
                _patientService.RewritePatientPlace(id, newPlace);
                return NoContent(); // Возвращаем 204, так как обновление прошло успешно
            }

            [HttpGet("Count")]
            public IActionResult GetCount()
            {
                var count = _patientService.CountPatient();
                return Ok(count);
            }
        }
    }
