using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class PlaceForInDTO
    {
        public int Id { get; set; }
        public char Day { get; set; }

        public int Time { get; set; }

        public int Ward { get; set; }
    }
}
