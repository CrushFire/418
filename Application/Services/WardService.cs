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
    public class WardService
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;

        public WardService(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<WardForInOutDTO>> GetAll(int page)
        {
            var wards = await _context.Set<Ward>().Skip((page - 1) * 25).Take(25).ToListAsync();
            List<WardForInOutDTO> wardsDTO = new List<WardForInOutDTO>();
            foreach (var w in wards)
            {
                wardsDTO.Add(_mapper.Map<WardForInOutDTO>(w));
            }
            return wardsDTO;
        }

        public void AddWard(WardForInOutDTO wardDTO)
        {
            var ward = _mapper.Map<Ward>(wardDTO);
            _context.Set<Ward>().Add(ward);
            _context.SaveChanges();
        }

        public void DeleteWard(int id)
        {
            var temp = _context.Set<Ward>().Find(id);
            _context.Remove<Ward>(temp);
            _context.SaveChanges();
        }
    }
}
