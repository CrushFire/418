using Core.DTO;
using DataAccess;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Security.Cryptography;

namespace Application.Services
{
    public class PatientService
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;
        public PatientService(MyDbContext context, IMapper mapper)
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

        /// <summary>
        /// Получение данных о пациенте
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<PatientForOutDTO> GetPatient(decimal id)
        {
            var patient = await _context.FindAsync<Patient>(id);
            return _mapper.Map<PatientForOutDTO>(patient);
        }

        /// <summary>
        /// Создание нового пациента
        /// </summary>
        /// <param name="patient"></param>
        public void CreatePatient(PatientWithOutIdDTO patientDTO)
        {
            patientDTO.Password = HashPasswordSHA128(patientDTO.Password);
            _context.Add(_mapper.Map<Patient>(patientDTO));//id?
            _context.SaveChanges();
        }

        /// <summary>
        /// Обновление данных о пациенте
        /// </summary>
        /// <param name="patient"></param>
        /// <param name="id"></param>
        public void UpdatePatient(PatientWithOutIdDTO patientDTO, decimal id)
        {
            var patient = _context.Find<Patient>(id);
            if (patient != null)
            {
                _mapper.Map(patientDTO, patient);//либо сюда маппинг где из дто преобразую в ту при условии, что айд иостается
            }
            patient.Id = id;
            _context.SaveChanges();
        }

        /// <summary>
        /// Удаление пациента
        /// </summary>
        /// <param name="id"></param>
        public void DeletePatient(decimal id)
        {
            var temp = _context.Find<Human>(id);//удаление каскадно?
            _context.Humans.Remove(temp);
            _context.SaveChanges();
        }

        /// <summary>
        /// Обновление места пациента
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newPlace"></param>
        public void RewritePatientPlace(decimal id, NewPlacePatientDTO newPlace)
        {
            var placePatient = _context.Set<Place>().Where(x => x.IdPatient == id).First();
            if (placePatient != null)
            {
                placePatient.IdPatient = null;//Status?
                placePatient.Status = false;
            }
            var place = _context.Set<Place>().Where(x => x.Id == newPlace.Id && x.Ward == newPlace.Ward && x.Day == newPlace.Day && x.Time == newPlace.Time).First();//Sytem.Type?
            place.IdPatient = id;
            place.Status = true;
            _context.SaveChanges();
        }

        public async Task<List<PatientForOutDTO>> GetAll(int page)
        {
            var patients = await _context.Set<Patient>().Skip((page - 1) * 25).Take(25).ToListAsync();
            List<PatientForOutDTO> patientsDTO = new List<PatientForOutDTO>();
            foreach (var p in patients)
            {
                patientsDTO.Add(_mapper.Map<PatientForOutDTO>(p));
            }
            return patientsDTO;
        }

        public int CountPatient()
        {
            return _context.Set<Patient>().Count();
        }
    }
}
