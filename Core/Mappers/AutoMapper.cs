using Core.DTO;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Core.Mappers
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<PatientWithOutIdDTO, Patient>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<PatientForOutDTO, Patient>();
            CreateMap<Patient, PatientForOutDTO>();
            CreateMap<Patient, PatientWithOutIdDTO>();

            CreateMap<DoctorWithOutIdDTO, Doctor>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<Doctor, DoctorWithOutIdDTO>();
            CreateMap<DoctorForOutDTO, Doctor>();
            CreateMap<Doctor, DoctorWithOutIdDTO>();
            CreateMap<Doctor, DoctorForOutDTO>();
            CreateMap<DoctorForOutDTO, Doctor>();

            CreateMap<HumanWithOutIdDTO, Human>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<Human, HumanForOutDTO>();

            CreateMap<Anamnesi, AnamnesForOutDTO>();
            CreateMap<AnamnesForInDTO, Anamnesi>();
            CreateMap<Anamnesi, AnamnesForInDTO>();

            CreateMap<Analisi, AnalisForOutDTO>();

            CreateMap<PlaceForInDTO, Place>();
            CreateMap<Place, PlaceForOutDTO>();
            CreateMap<PlaceForInDTO, PlaceForOutDTO>();
            CreateMap<Place, PlaceForOutDTO>();
            CreateMap<PlaceForOutDTO, Place>();
            CreateMap<Place, PlaceForInWithOutDayDTO>();
            CreateMap<PlaceForInWithOutDayDTO, Place>();

            CreateMap<WardForInOutDTO, Ward>();
            CreateMap<Ward, WardForInOutDTO>();

            CreateMap<Treatment, TreatmentForOutDTO>();
            CreateMap<TreatmentForOutDTO, Treatment>();
            CreateMap<Treatment, TreatmentForInDTO>();
            CreateMap<TreatmentForInDTO, Treatment>();
            CreateMap<TreatmentForOutDTO, TreatmentForInDTO>();
            CreateMap<TreatmentForInDTO, TreatmentForOutDTO>();

        }
    }
}
