using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class TreatmentForOutDTO
    {
        public decimal Id { get; set; }
        public string Drug { get; set; } = null!;

        public string Recomendation { get; set; } = null!;

        public DateOnly Date { get; set; }

        public string Health { get; set; } = null!;

        public string Analysis { get; set; } = null!;

        public string Diagnosis { get; set; } = null!;

        public int DurationHealth { get; set; }

        public string FioPatient { get; set; }

        public string FioDoctor { get; set; }
    }
}
