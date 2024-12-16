using AutoMapper;
using Core.DTO;
using DataAccess;
using DataAccess.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AnalisService
    {
        private readonly MyDbContext _context;
        private readonly IWebHostEnvironment _appEnvironment;
        private readonly IMapper _mapper;

        public AnalisService(MyDbContext context, IWebHostEnvironment appEnvironment, IMapper mapper)
        {
            _context = context;
            _appEnvironment = appEnvironment;
            // Указываем путь для хранения файлов в директории "Uploads" (в проекте)
            _mapper = mapper;
        }

        // Метод для получения всех файлов из базы данных
        public async Task<List<Analisi>> GetAllFiles(int page)
        {
            return await _context.Set<Analisi>().Skip((page - 1) * 15).Take(15).ToListAsync();
        }

        public void AddFile(IFormFile uploadedFile, decimal idTreatment)
        {
            // Путь для сохранения файла
            var uploadPath = Path.Combine(_appEnvironment.WebRootPath, "uploads");  // Это папка в wwwroot

            // Создаем папку, если ее нет
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            // Генерация уникального имени для файла
            var fileName = $"{idTreatment}_{DateTime.UtcNow:yyyyMMddHHmmss}.png";
            var filePath = Path.Combine(uploadPath, fileName);

            // Сохраняем файл
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                uploadedFile.CopyToAsync(fileStream);
            }

            Analisi analisi = new Analisi();
            analisi.Wave = filePath;
            analisi.IdTreatment = idTreatment;
            _context.Set<Analisi>().Add(analisi);
            _context.SaveChanges();
        }

        public void DeleteFile(decimal id)
        {
            var temp = _context.Set<Analisi>().Find(id);
            var path = temp.Wave;

            var uploadPath = Path.Combine(_appEnvironment.WebRootPath, "uploads", path);  // Это папка в wwwroot

            if (File.Exists(uploadPath))
            {
                // Удаляем файл
                File.Delete(uploadPath);
                _context.Analises.Remove(temp);
                _context.SaveChanges();
            }
            else
            {
                throw new FileNotFoundException("Файл не найден", uploadPath);
            }
        }

        public async Task<AnalisForOutDTO> GetAnalis(decimal id)
        {
            var analis = await _context.Set<Analisi>().FindAsync(id);
            return _mapper.Map<AnalisForOutDTO>(analis);
        }

        public List<AnalisForOutDTO> GetAnalisisForPatient(decimal idPatient, int page)
        {
            var treatments = _context.Set<Treatment>().Where(x => x.IdPatient == idPatient).Skip((page - 1) * 25).Take(25).ToList();
            List<decimal> treatmentsId = new List<decimal>();
            List<Analisi> analisis = new List<Analisi>();
            List<AnalisForOutDTO> analisisDTO = new List<AnalisForOutDTO>();
            foreach(var t in treatments)
            {
                treatmentsId.Add(t.Id);
            }
            foreach(var t in treatmentsId)
            {
                analisis.AddRange(_context.Set<Analisi>().Where(x => x.IdTreatment == t));
            }
            foreach(var a in analisis)
            {
                analisisDTO.Add(_mapper.Map<AnalisForOutDTO>(a));
            }

            return analisisDTO;
        }
    }
}
