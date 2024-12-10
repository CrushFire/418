using System;
using System.Collections.Generic;

namespace DataAccess.Entities;

public partial class Treatment
{
    public decimal Id { get; set; }

    public string Drug { get; set; } = null!;

    public string Recomendation { get; set; } = null!;

    public DateOnly Date { get; set; }

    public string Health { get; set; } = null!;

    public string Analysis { get; set; } = null!;

    public string Diagnosis { get; set; } = null!;

    public int DurationHealth { get; set; }

    public decimal IdPatient { get; set; }

    public decimal IdDoctor { get; set; }

    public virtual ICollection<Analisi> Analisis { get; set; } = new List<Analisi>();

    public virtual Patient IdPatientNavigation { get; set; } = null!;
}
