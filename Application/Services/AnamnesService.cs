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
    public class AnamnesService
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;

        public AnamnesService(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

            public async Task<AnamnesForOutDTO> GetAnamnes(decimal id)
            {
                var anamnes = await _context.FindAsync<Anamnesi>(id);
                var anamnesDTO = _mapper.Map<AnamnesForOutDTO>(anamnes);
                anamnesDTO.FioDoctor = _context.Find<Doctor>(anamnes.IdDoctor).Fio;
                var patient = _context.Find<Patient>(anamnes.IdPatient);
                anamnesDTO.FioPatient = patient.SecondName + " " + patient.Name + " " + patient.Otchestvo;
                return anamnesDTO;
            }

            public void CreateAnamnes(AnamnesForInDTO anamnesDTO)
            {
                _context.Add(_mapper.Map<Anamnesi>(anamnesDTO));//id?
                _context.SaveChanges();
            }

            public void UpdateAnamnes(AnamnesForInDTO anamnesDTO, decimal id)
            {
            var anamnes = _context.Find<Anamnesi>(id);
            var date = anamnes.Date;
            if (anamnes != null)
            {
                _mapper.Map(anamnesDTO, anamnes);//либо сюда маппинг где из дто преобразую в ту при условии, что айд иостается
            }
            anamnes.Id = id;
            anamnes.Date = date;
            _context.SaveChanges();
        }

            public void DeleteAnamnes(decimal id)
            {
                var temp = _context.Find<Anamnesi>(id);//удаление каскадно?
                _context.Anamneses.Remove(temp);
                _context.SaveChanges();
            }

            public async Task<List<AnamnesForOutDTO>> GetAll()
            {
                var anamnesis = await _context.Set<Anamnesi>().ToListAsync();
                List<AnamnesForOutDTO> anamnesisDTO = new List<AnamnesForOutDTO>();
                foreach (var a in anamnesis)
                {
                    var anamnesDTO = _mapper.Map<AnamnesForOutDTO>(a);
                    anamnesDTO.FioDoctor = _context.Find<Doctor>(a.IdDoctor).Fio;
                    var patient = _context.Find<Patient>(a.IdPatient);
                    anamnesDTO.FioPatient = patient.Name + patient.SecondName + patient.Otchestvo;
                    anamnesisDTO.Add(anamnesDTO);
                }
                return anamnesisDTO;
            }

            public async Task<List<AnamnesForOutDTO>> GetAnamnesisForPatient(int page, int idPatient)
            {
                var anamnesis = _context.Set<Anamnesi>().Where(x => x.IdPatient == idPatient);
                List<AnamnesForOutDTO> anamnesisDTO = new List<AnamnesForOutDTO>();
                foreach(var a in anamnesis)
                {
                    anamnesisDTO.Add(_mapper.Map<AnamnesForOutDTO>(a));
                }

                return anamnesisDTO;
            }

            public int Count()
        {
            return _context.Set<Anamnesi>().Count();
        }

            public int CountForPatient(decimal idPatient)
        {
            return _context.Set<Anamnesi>().Where(x => x.IdPatient == idPatient).Count();
        }
        }
    }
