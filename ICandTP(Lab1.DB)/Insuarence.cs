using System;
using System.Collections.Generic;

namespace ICandTP_Lab1.DB_;

public partial class Insuarence
{
    public int Id { get; set; }

    public DateTime IssueDate { get; set; }

    public DateTime ExpirationDate { get; set; }

    public string VechicleVin { get; set; } = null!;

    public string Type { get; set; } = null!;

    public virtual ICollection<Vechicle> Vechicles { get; } = new List<Vechicle>();
}
