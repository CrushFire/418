using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class PatientWithOutIdDTO
    {
        public char Gender { get; set; }

        public string PhoneNumber { get; set; } = null!;

        public string Passport { get; set; } = null!;

        public string Omc { get; set; } = null!;

        public string Cnils { get; set; } = null!;

        public DateOnly Birthday { get; set; }

        public string Address { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string SecondName { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Otchestvo { get; set; } = null!;
    }
}
