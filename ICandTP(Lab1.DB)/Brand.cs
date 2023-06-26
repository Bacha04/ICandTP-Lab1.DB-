using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ICandTP_Lab1.DB_;

public partial class Brand
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Поле не повинно бути порожнім!")]
    [Display(Name = "Назва")]
    public string BrandName { get; set; } = null!;

    [Required(ErrorMessage = "Поле не повинно бути порожнім!")]
    [Display(Name = "Країна")]
    public int CountryId { get; set; }

    [Display(Name = "Консерн")]
    public string? Concern { get; set; }

    [Display(Name = "Країна")]
    public virtual Country Country { get; set; } = null!;

    public virtual ICollection<Model> Models { get; } = new List<Model>();
}
