using System;
using System.Collections.Generic;

namespace DataAccess.Entities;

public partial class Place
{
    public int Id { get; set; }

    public char Day { get; set; }

    public DateOnly Date { get; set; }

    public int Time { get; set; }

    public bool Status { get; set; }

    public int Ward { get; set; }

    public decimal? IdPatient { get; set; }

    public virtual Human? IdPatientNavigation { get; set; }

    public virtual Ward WardNavigation { get; set; } = null!;
}
