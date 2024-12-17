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
    public class HumanService
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;
        public HumanService(MyDbContext context, IMapper mapper)
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

        public async Task<List<HumanForOutDTO>> GetAllAdmin()
        {
            var humans = await _context.Set<Human>().Where(x => x.Role == 0).OrderBy(x => x.Id).ToListAsync();
            List<HumanForOutDTO> humansDTO = new List<HumanForOutDTO>();
            foreach(var h in humans)
            {
                humansDTO.Add(_mapper.Map<HumanForOutDTO>(h));
            }
            return humansDTO;
        }

        public void DeleteAdmin(decimal id)
        {
            var temp = _context.Set<Human>().Where(x => x.Role == 0 && x.Id == id).First();
            _context.Remove<Human>(temp);
            _context.SaveChanges();
        }

        public void CreateAdmin(HumanWithOutIdDTO humanDTO)
        {
            humanDTO.Password = HashPasswordSHA128(humanDTO.Password);
            _context.Add(_mapper.Map<Human>(humanDTO));
            _context.SaveChanges();
        }

        public int Count()
        {
            return _context.Set<Human>().Where(x => x.Role == 0).Count();
        }
    }
}
