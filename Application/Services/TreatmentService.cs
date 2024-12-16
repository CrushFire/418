using AutoMapper;
using Core.DTO;
using DataAccess;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TreatmentService
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;

        public TreatmentService(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TreatmentForOutDTO> GetTreatmens(decimal id)
        {
            var treatmen = await _context.FindAsync<Treatment>(id);
            var treatmentDTO = _mapper.Map<TreatmentForOutDTO>(treatmen);
            treatmentDTO.FioDoctor = _context.Find<Doctor>(treatmen.IdDoctor).Fio;
            var patient = _context.Find<Patient>(treatmen.IdPatient);
            treatmentDTO.FioPatient = patient.SecondName + " " + patient.Name + " " + patient.Otchestvo;
            return treatmentDTO;
        }

        public void CreateAnamnes(TreatmentForInDTO treatmentDTO)
        {
            _context.Add(_mapper.Map<Treatment>(treatmentDTO));//id?
            _context.SaveChanges();
        }

        public void UpdateAnamnes(TreatmentForInDTO treatmentDTO, decimal id)
        {
            var treatment = _context.Find<Treatment>(id);
            if (treatment != null)
            {
                _mapper.Map(treatmentDTO, treatment);//либо сюда маппинг где из дто преобразую в ту при условии, что айд иостается
            }
            treatment.Id = id;
            _context.SaveChanges();
        }

        public void DeleteAnamnes(decimal id)
        {
            var temp = _context.Find<Treatment>(id);//удаление каскадно?
            _context.Remove<Treatment>(temp);
            _context.SaveChanges();
        }

        public async Task<List<TreatmentForOutDTO>> GetAll(int page)
        {
            var treatments = await _context.Set<Treatment>().Skip((page - 1) * 25).Take(25).ToListAsync();
            List<TreatmentForOutDTO> treatmentsDTO = new List<TreatmentForOutDTO>();
            foreach (var t in treatments)
            {
                var treatmentDTO = _mapper.Map<TreatmentForOutDTO>(t);
                treatmentDTO.FioDoctor = _context.Find<Doctor>(t.IdDoctor).Fio;
                var patient = _context.Find<Patient>(t.IdPatient);
                treatmentDTO.FioPatient = patient.Name + patient.SecondName + patient.Otchestvo;
                treatmentsDTO.Add(treatmentDTO);
            }
            return treatmentsDTO;
        }

        public async Task<List<TreatmentForOutDTO>> GetTreatmentsForPatient(int page, int idPatient)
        {
            var treatments = await _context.Set<Treatment>().Where(x => x.IdPatient == idPatient).ToListAsync();
            List<TreatmentForOutDTO> treatmentsDTO = new List<TreatmentForOutDTO>();
            foreach(var t in treatments)
            {
                treatmentsDTO.Add(_mapper.Map<TreatmentForOutDTO>(t));
            }

            return treatmentsDTO;
        }

        public int Count()
        {
            return _context.Set<Treatment>().Count();
        }

        public int CountForPatient(int idPatient)
        {
            return _context.Set<Treatment>().Where(x => x.IdPatient == idPatient).Count();
        }
    }
}
