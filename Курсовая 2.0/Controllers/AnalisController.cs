using Application.Services;
using DataAccess;
using DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace Курсовая_2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalisController : ControllerBase
    {
        private readonly AnalisService _analisService;
        private readonly IWebHostEnvironment _appEnvironment;
        private readonly MyDbContext _context;
        public AnalisController(IWebHostEnvironment appEnvironment, MyDbContext context, AnalisService analisService)
        {
            _appEnvironment = appEnvironment;
            _context = context;
            _analisService = analisService;
        }

        //// Эндпоинт для загрузки файла
        //[HttpPost("upload/{id}")]
        //public async Task<IActionResult> UploadFile([FromForm] IFormFile file, [FromRoute] decimal id)
        //{
        //    try
        //    {
        //        if (file == null || file.Length == 0)
        //        {
        //            return BadRequest("No file uploaded");
        //        }

        //        // Сохраняем файл с уникальным именем
        //        var filePath = await _analisService.SaveAnalis(file, id);

        //        // Возвращаем путь к файлу в ответе
        //        return Ok(new { FilePath = filePath });
        //    }
        //    catch (ArgumentException ex)
        //    {
        //        // Обработка ошибок, связанных с файлом (например, неправильный формат)
        //        return BadRequest(ex.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Обработка других ошибок
        //        return StatusCode(500, $"Internal server error: {ex.Message}");
        //    }
        //}

        //// Эндпоинт для получения всех файлов (с пагинацией)
        //[HttpGet("files")]
        //public async Task<IActionResult> GetAllFiles([FromQuery] int page = 1)
        //{
        //    try
        //    {
        //        var files = await _analisService.GetAllFilesAsync(page);
        //        return Ok(files);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Internal server error: {ex.Message}");
        //    }
        //}

        //[HttpPost]
        //public IActionResult AddFile(IFormFile uploadedFile, int idTreatment)
        //{
        //    _analisService.AddFile(uploadedFile, idTreatment);
        //    return Ok();
        //}

        [HttpPost("upload/{idTreatment}")]
        public IActionResult UploadFile(IFormFile uploadedFile, [FromRoute] decimal idTreatment)
        {
            _analisService.AddFile(uploadedFile, idTreatment);

            return Ok();
        }
        [HttpDelete("upload/{id}")]
        public IActionResult Delete([FromRoute] decimal id)
        {
            _analisService.DeleteFile(id);

            return Ok();
        }

        [HttpGet("upload")]
        public async Task<IActionResult> GetAllFiles()
        {
            var temp = await _analisService.GetAllFiles();

            return Ok(temp);
        }

        [HttpGet("upload/{id}")]
        public async Task<IActionResult> GetFile(int id)
        {
            var temp = await _analisService.GetAnalis(id);

            return Ok(temp);
        }

        [HttpGet("{idPatient}")]
        public IActionResult GetAnalisisForPatient(decimal idPatient, int page)
        {
            var temp = _analisService.GetAnalisisForPatient(idPatient, page);

            return Ok(temp);
        }

    }
}