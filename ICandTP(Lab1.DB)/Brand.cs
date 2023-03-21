using System;
using System.Collections.Generic;

namespace ICandTP_Lab1.DB_;

public partial class Brand
{
    public int Id { get; set; }

    public string BrandName { get; set; } = null!;

    public int CountryId { get; set; }

    public string? Concern { get; set; }

    public virtual Country Country { get; set; } = null!;

    public virtual ICollection<Model> Models { get; } = new List<Model>();
}
