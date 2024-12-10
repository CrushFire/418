using System;
using System.Collections.Generic;

namespace DataAccess.Entities;

public partial class Anamnesi
{
    public decimal Id { get; set; }

    public string Complaint { get; set; } = null!;

    public string Prediagnosis { get; set; } = null!;

    public decimal IdDoctor { get; set; }

    public DateOnly Date { get; set; }

    public decimal IdPatient { get; set; }

    public virtual Doctor IdDoctorNavigation { get; set; } = null!;

    public virtual Patient IdPatientNavigation { get; set; } = null!;
}
