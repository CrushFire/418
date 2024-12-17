using AutoMapper;
using Core.DTO;
using DataAccess;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class DoctorService
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;
        public DoctorService(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public static string HashPasswordSHA128(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Хешируем пароль
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);

                // Берем только первые 16 байт (128 бит) из результата SHA-256
                byte[] shortHashBytes = new byte[16];
                Array.Copy(hashBytes, shortHashBytes, 16);
                StringBuilder hex = new StringBuilder(shortHashBytes.Length * 2);
                foreach (byte b in shortHashBytes)
                {
                    hex.AppendFormat("{0:x2}", b);
                }

                // Возвращаем хеш в строке Base64, который будет длиной 22 символа
                return hex.ToString();
            }
        }

        public async Task<DoctorForOutDTO> GetDoctor(decimal id)
        {
            var doctor = await _context.FindAsync<Doctor>(id);
            return _mapper.Map<DoctorForOutDTO>(doctor);
        }

        public void CreateDoctor(DoctorWithOutIdDTO doctorDTO)
        {
            doctorDTO.Password = HashPasswordSHA128(doctorDTO.Password);
            _context.Add(_mapper.Map<Doctor>(doctorDTO));
            _context.SaveChanges();
        }

        public void UpdateDoctor(DoctorWithOutIdDTO doctorDTO, decimal id)
        {
            var doctor = _context.Find<Doctor>(id);
            if(doctor != null)
            {
                _mapper.Map(doctorDTO, doctor);//поправить
            }

            doctor.Id = id;
            
            _context.SaveChanges();
        }

        public void DeleteDoctor(decimal id)
        {
            var temp = _context.Find<Human>(id);
            _context.Humans.Remove(temp);
            _context.SaveChanges();
        }

        public async Task<List<DoctorForOutDTO>> GetAllDoctor()
        {
            var doctors = await _context.Set<Doctor>().OrderBy(x => x.Id).ToListAsync();
            List<DoctorForOutDTO> doctorsDTO = new List<DoctorForOutDTO>();
            foreach(var d in doctors)
            {
                doctorsDTO.Add(_mapper.Map<DoctorForOutDTO>(d));
            }
            return doctorsDTO;
        }

        public int Count()
        {
            return _context.Set<Doctor>().Count();
        }
    }
}
