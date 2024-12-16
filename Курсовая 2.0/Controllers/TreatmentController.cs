using Application.Services;
using Core.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace YourNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreatmentController : ControllerBase
    {
        private readonly TreatmentService _treatmentService;

        public TreatmentController(TreatmentService treatmentService)
        {
            _treatmentService = treatmentService;
        }

        // GET: api/Treatment/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTreatment(decimal id)
        {
            var treatment = await _treatmentService.GetTreatmens(id);
            if (treatment == null)
            {
                return NotFound();
            }
            return Ok(treatment);
        }

        // POST: api/Treatment
        [HttpPost]
        public IActionResult CreateTreatment([FromBody] TreatmentForInDTO treatmentDTO)
        {
            if (treatmentDTO == null)
            {
                return BadRequest("Invalid data.");
            }

            _treatmentService.CreateAnamnes(treatmentDTO);
            return Ok();
        }

        // PUT: api/Treatment/5
        [HttpPut("{id}")]
        public IActionResult UpdateTreatment(decimal id, [FromBody] TreatmentForInDTO treatmentDTO)
        {
            if (treatmentDTO == null)
            {
                return BadRequest("Invalid data.");
            }

            try
            {
                _treatmentService.UpdateAnamnes(treatmentDTO, id);
            }
            catch
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Treatment/5
        [HttpDelete("{id}")]
        public IActionResult DeleteTreatment(decimal id)
        {
            _treatmentService.DeleteAnamnes(id);
            return NoContent();
        }

        // GET: api/Treatment
        [HttpGet]
        public async Task<IActionResult> GetAllTreatments(int page = 1)
        {
            var treatments = await _treatmentService.GetAll(page);
            return Ok(treatments);
        }

        // GET: api/Treatment/Patient/5
        [HttpGet("Patient/{idPatient}")]
        public async Task<IActionResult> GetTreatmentsForPatient(int idPatient, int page = 1)
        {
            var treatments = await _treatmentService.GetTreatmentsForPatient(page, idPatient);
            return Ok(treatments);
        }

        // GET: api/Treatment/Count
        [HttpGet("Count")]
        public IActionResult GetTreatmentCount()
        {
            var count = _treatmentService.Count();
            return Ok(count);
        }

        // GET: api/Treatment/Patient/Count/5
        [HttpGet("Patient/Count/{idPatient}")]
        public IActionResult GetTreatmentCountForPatient(int idPatient)
        {
            var count = _treatmentService.CountForPatient(idPatient);
            return Ok(count);
        }
    }
}
