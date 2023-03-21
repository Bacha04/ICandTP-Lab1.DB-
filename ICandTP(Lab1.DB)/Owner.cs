using System;
using System.Collections.Generic;

namespace ICandTP_Lab1.DB_;

public partial class Owner
{
    public int Tin { get; set; }

    public string FullName { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public string City { get; set; } = null!;

    public int CountryId { get; set; }

    public virtual Country Country { get; set; } = null!;

    public virtual ICollection<Vechicle> Vechicles { get; } = new List<Vechicle>();
}
