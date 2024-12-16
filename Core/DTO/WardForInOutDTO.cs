using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class WardForInOutDTO
    {
        public int Id { get; set; }

        public char Gender { get; set; }

        public int CountPlace { get; set; }
    }
}
