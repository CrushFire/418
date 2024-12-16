using AutoMapper;
using Core.DTO;
using DataAccess;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PlaceService
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;
        public PlaceService(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<PlaceForOutDTO>> GetAllPlace(int page)
        {
            var places = await _context.Set<Place>().Skip((page - 1) * 25).Take(25).OrderBy(x => x.IdPatient).ToListAsync();
            List<PlaceForOutDTO> placesDTO = new List<PlaceForOutDTO>();
            foreach(var p in places)
            {
                placesDTO.Add(_mapper.Map<PlaceForOutDTO>(p));
            }
            return placesDTO;
        }

        //public async Task<List<PlaceForOutDTO>> GetAllForPatient(int page, char gender)
        //{
        //    var places = await _context.Set<Place>().Skip((page - 1) * 25).Take(25).OrderBy(x => x.IdPatient).ToListAsync();
        //    List<PlaceForOutDTO> placesDTO = new List<PlaceForOutDTO>();
        //    foreach (var p in places)
        //    {
        //        placesDTO.Add(_mapper.Map<PlaceForOutDTO>(p));
        //    }
        //    return placesDTO;
        //}

        public void AddPlace(PlaceForInWithOutDayDTO placeDTO)
        {
            var place = _mapper.Map<Place>(placeDTO);
            place.Day = 'с';
            _context.Add(place);
            place.Day = 'з';
            _context.Add(place);
            _context.SaveChanges();
        }

        public void DeletePlace(PlaceForInWithOutDayDTO placeDTO)
        {
            var temp = _context.Set<Place>().Where(x => x.Id == placeDTO.Id && x.Ward == placeDTO.Ward && x.Time == placeDTO.Time);//Test
            foreach (var t in temp)
            {
                _context.Set<Place>().Remove(t);
            }
            _context.SaveChanges();
        }

        public void ClearPlace(PlaceForInDTO placeDTO)
        {
            var temp = _context.Set<Place>().Where(x => x.Id == placeDTO.Id && x.Ward == placeDTO.Ward && x.Day == placeDTO.Day && x.Time == placeDTO.Time).First();//Test
            temp.IdPatient = null;
            temp.Status = false;
            _context.SaveChanges();
        }

        //public async Task<PlaceForOutDTO> GetPlace(PlaceForInDTO placeDTO)
        //{
        //    var place = _context.Set<Place>().Where(x => x.Id == placeDTO.Id && x.Ward == placeDTO.Ward && x.Day == placeDTO.Day && x.Time == placeDTO.Time).First();//Test)
        //    var placeOutDTO = _mapper.Map<PlaceForOutDTO>(place);
        //    return placeOutDTO;
        //}

        public void UpdateTimePlaces()
        {
            // Fetch places for today and tomorrow into memory
            var placesToday = _context.Set<Place>()
                                      .Where(x => x.Day == 'с')  // Filter for today
                                      .OrderBy(x => x.Id)
                                      .ToList();  // Bring data into memory

            var placesTomorrow = _context.Set<Place>()
                                         .Where(x => x.Day == 'з')  // Filter for tomorrow
                                         .OrderBy(x => x.Id)
                                         .ToList();  // Bring data into memory

            // Apply Zip operation on the in-memory lists
            var combined = placesToday.Zip(placesTomorrow, (item1, item2) => new { item1, item2 });

            foreach (var c in combined)
            {
                if (c.item2.IdPatient != null)
                {
                    // Transfer patient data from tomorrow's place to today's place
                    c.item1.IdPatient = c.item2.IdPatient;
                    c.item1.Status = true;
                    c.item1.Date = DateOnly.FromDateTime(DateTime.Today);  // Update date for today's place

                    // Update tomorrow's place
                    c.item2.IdPatient = null;
                    c.item2.Status = false;
                    c.item2.Date = DateOnly.FromDateTime(DateTime.Today.AddDays(1));  // Update date for tomorrow's place

                    // Explicitly mark items as modified
                    _context.Entry(c.item1).State = EntityState.Modified;
                    _context.Entry(c.item2).State = EntityState.Modified;
                }
            }

            // Save the changes to the database
            _context.SaveChanges();
        }



        public int Count()
        {
            return _context.Set<Place>().Count();
        }
    }
}
