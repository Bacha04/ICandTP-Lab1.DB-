using System;
using System.Collections.Generic;

namespace ICandTP_Lab1.DB_;

public partial class Model
{
    public int Id { get; set; }

    public string ModelName { get; set; } = null!;

    public int BrandId { get; set; }

    public string BodyTypes { get; set; } = null!;

    public string? Localisation { get; set; }

    public virtual Brand Brand { get; set; } = null!;

    public virtual ICollection<Vechicle> Vechicles { get; } = new List<Vechicle>();
}
