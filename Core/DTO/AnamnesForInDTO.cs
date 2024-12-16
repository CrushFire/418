using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class AnamnesForInDTO
    {
        public string Complaint { get; set; } = null!;

        public string Prediagnosis { get; set; } = null!;

        public decimal IdDoctor { get; set; }

        public decimal IdPatient { get; set; }
    }
}
