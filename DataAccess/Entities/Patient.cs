using System;
using System.Collections.Generic;

namespace DataAccess.Entities;

public partial class Patient
{
    public char Gender { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string Passport { get; set; } = null!;

    public string Omc { get; set; } = null!;

    public string Cnils { get; set; } = null!;

    public decimal Id { get; set; }

    public DateOnly Birthday { get; set; }

    public string Address { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string SecondName { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Otchestvo { get; set; } = null!;

    public virtual ICollection<Anamnesi> Anamnesis { get; set; } = new List<Anamnesi>();

    public virtual Human IdNavigation { get; set; } = null!;

    public virtual ICollection<Treatment> Treatments { get; set; } = new List<Treatment>();
}
