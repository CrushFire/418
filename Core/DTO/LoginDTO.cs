using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class LoginDTO
    {
        public decimal Id { get; set; }

        public string Password { get; set; } = null!;
    }
}
