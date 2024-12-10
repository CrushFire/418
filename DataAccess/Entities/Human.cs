using System;
using System.Collections.Generic;

namespace DataAccess.Entities;

public partial class Human
{
    public decimal Id { get; set; }

    public int Role { get; set; }

    public string Password { get; set; } = null!;

    public virtual Doctor? Doctor { get; set; }

    public virtual Patient? Patient { get; set; }

    public virtual ICollection<Place> Places { get; set; } = new List<Place>();
}
