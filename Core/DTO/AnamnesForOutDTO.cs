using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class AnamnesForOutDTO
    {
        public decimal Id { get; set; }
        public string Complaint { get; set; } = null!;

        public string Prediagnosis { get; set; } = null!;

        public string FioDoctor { get; set; }

        public DateOnly Date { get; set; }

        public string FioPatient {  get; set; }
    }
}
