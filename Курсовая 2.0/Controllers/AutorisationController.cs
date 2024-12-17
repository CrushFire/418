using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Курсовая_2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorisationController : ControllerBase
    {
        private readonly AutorisationService _authorisationService;

        public AutorisationController(AutorisationService authorisationService)
        {
            _authorisationService = authorisationService;
        }
        [HttpGet("Id")]
        public IActionResult CheckHuman(decimal id, string password)
        {
            var idHuman = _authorisationService.CheckHuman(id, password);

            return Ok(idHuman);
        }
    }
}
