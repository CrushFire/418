using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class TreatmentForInDTO
    {
        public string Drug { get; set; } = null!;

        public string Recomendation { get; set; } = null!;

        public string Health { get; set; } = null!;

        public string Analysis { get; set; } = null!;

        public string Diagnosis { get; set; } = null!;

        public int DurationHealth { get; set; }

        public decimal IdPatient { get; set; }

        public decimal IdDoctor { get; set; }
    }
}
