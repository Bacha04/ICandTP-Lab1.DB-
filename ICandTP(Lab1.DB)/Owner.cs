using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ICandTP_Lab1.DB_;

public partial class Owner
{
    public int Tin { get; set; }

    [Required(ErrorMessage = "Поле не повинно бути порожнім!")]
    [Display(Name = "ПІБ")]
    public string FullName { get; set; } = null!;

    [Required(ErrorMessage = "Поле не повинно бути порожнім!")]
    [Display(Name = "Дата народження")]
    public DateTime DateOfBirth { get; set; }

    [Required(ErrorMessage = "Поле не повинно бути порожнім!")]
    [Display(Name = "Місто")]
    public string City { get; set; } = null!;

    [Display(Name = "Країна")]
    public int CountryId { get; set; }
  

    [Display(Name = "Країна")]
    public virtual Country Country { get; set; } = null!;

    public virtual ICollection<Vechicle> Vechicles { get; } = new List<Vechicle>();
}
