using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ICandTP_Lab1.DB_;

public partial class Country
{

    public int Id { get; set; }
    [Required(ErrorMessage ="Поле не повинно бути порожнім!")]
    [Display(Name = "Назва країни")]
    public string CountryName { get; set; } = null!;

    public virtual ICollection<Brand> Brands { get; } = new List<Brand>();

    public virtual ICollection<Owner> Owners { get; } = new List<Owner>();
}
