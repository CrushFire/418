using System;
using System.Collections.Generic;

namespace DataAccess.Entities;

public partial class Doctor
{
    public decimal Id { get; set; }

    public string Fio { get; set; } = null!;

    public string Qualification { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Anamnesi> Anamnesis { get; set; } = new List<Anamnesi>();

    public virtual Human IdNavigation { get; set; } = null!;
}
