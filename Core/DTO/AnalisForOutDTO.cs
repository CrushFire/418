using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class AnalisForOutDTO
    {
        public decimal Id { get; set; }
        public DateOnly DataDownoald { get; set; }

        public string Wave { get; set; } = null!;

        public decimal IdTreatment { get; set; }
    }
}
