using Application.Services;
using Core.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace YourNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceController : ControllerBase
    {
        private readonly PlaceService _placeService;

        public PlaceController(PlaceService placeService)
        {
            _placeService = placeService;
        }

        // GET: api/Place?page=1
        [HttpGet]
        public async Task<IActionResult> GetAllPlace([FromQuery] int page)
        {
            try
            {
                var places = await _placeService.GetAllPlace(page);
                return Ok(places);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/Place/5
        //[HttpGet("One")]
        //public async Task<IActionResult> GetPlace([FromBody] PlaceForInDTO placeDTO)
        //{
        //    try
        //    {
        //        var place = await _placeService.GetPlace(placeDTO);
        //        return Ok(place);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Internal server error: {ex.Message}");
        //    }
        //}

        // POST: api/Place
        [HttpPost]
        public IActionResult AddPlace([FromBody] PlaceForInWithOutDayDTO placeDTO)
        {
            try
            {
                _placeService.AddPlace(placeDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/Place
        [HttpDelete]
        public IActionResult DeletePlace([FromBody] PlaceForInWithOutDayDTO placeDTO)
        {
            try
            {
                _placeService.DeletePlace(placeDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/Place/clear
        [HttpPut("clear")]
        public IActionResult ClearPlace([FromBody] PlaceForInDTO placeDTO)
        {
            try
            {
                _placeService.ClearPlace(placeDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/Place/update-time
        [HttpPut("update-time")]
        public IActionResult UpdateTimePlaces()
        {
            try
            {
                _placeService.UpdateTimePlaces();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("Count")]
        public IActionResult Count()
        {
            var count = _placeService.Count();
            return Ok(count);
        }
    }
}
