using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ICandTP_Lab1.DB_;

public partial class Model
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Поле не повинно бути порожнім!")]
    [Display(Name = "Назва моделі")]
    public string ModelName { get; set; } = null!;

    [Required(ErrorMessage = "Поле не повинно бути порожнім!")]
    [Display(Name = "Бренд")]
    public int BrandId { get; set; }

    [Required(ErrorMessage = "Поле не повинно бути порожнім!")]
    [Display(Name = "Тип кузова")]
    public string BodyTypes { get; set; } = null!;

    [Display(Name = "Ринок продажу")]
    public string? Localisation { get; set; }

    [Display(Name = "Марка")]
    public virtual Brand Brand { get; set; } = null!;

    public virtual ICollection<Vechicle> Vechicles { get; } = new List<Vechicle>();
}
