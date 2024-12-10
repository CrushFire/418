using System;
using System.Collections.Generic;

namespace DataAccess.Entities;

public partial class Analisi
{
    public decimal Id { get; set; }

    public DateOnly DataDownoald { get; set; }

    public string Wave { get; set; } = null!;

    public decimal IdTreatment { get; set; }

    public virtual Treatment IdTreatmentNavigation { get; set; } = null!;
}
