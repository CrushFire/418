using System;
using System.Collections.Generic;

namespace DataAccess.Entities;

public partial class Ward
{
    public int Id { get; set; }

    public char Gender { get; set; }

    public int CountPlace { get; set; }

    public virtual ICollection<Place> Places { get; set; } = new List<Place>();
}
