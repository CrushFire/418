using DataAccess;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AutorisationService
    {
        private readonly MyDbContext _context;

        public AutorisationService(MyDbContext context)
        {
            _context = context;
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

        //public decimal CheckPatient(string phoneNumber, string password)
        //{
        //    password = HashPasswordSHA128(password);
        //    var patients = _context.Set<Patient>().ToList();
        //    foreach (var p in patients)
        //    {
        //        if (p.PhoneNumber == phoneNumber && p.Passport == password)
        //        {
        //            return p.Id;
        //        }
        //    }
        //    return -1;
        //}

        //public decimal CheckDoctor(decimal id, string password)
        //{
        //    password = HashPasswordSHA128(password);
        //    var doctors = _context.Set<Doctor>().ToList();
        //    foreach(var d in doctors)
        //    {
        //        if(d.Id == id && d.Password == password)
        //        {
        //            return d.Id;
        //        }
        //    }
        //    return -1;
        //}

        public Human CheckHuman(decimal id, string password)
        {
            password = HashPasswordSHA128(password);
            var admins = _context.Set<Human>().ToList();
            foreach(var a in admins)
            {
                if(a.Id == id && a.Password == password)
                {
                    return a;
                }
            }
            return null;
        }
    }
}
