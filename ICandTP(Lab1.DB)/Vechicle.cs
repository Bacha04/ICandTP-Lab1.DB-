using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace ICandTP_Lab1.DB_;

public partial class Vechicle
{
    public string Vin { get; set; } = null!;
    [Display(Name = "VIN Код")]

    public double EngineCapacity { get; set; }
    [Display(Name = "Об'єм двигуна")]

    public int ModelId { get; set; }
    [Display(Name = "ID моделі")]
    public int InsuarenceId { get; set; }
    [Display(Name = "ID страхування")]
    public string PlateNum { get; set; } = null!;
    [Display(Name = "Номерний знак")]
    public DateTime DateOfIssue { get; set; }
    [Display(Name = "Дата випуску машини")]
    public int OwnerTin { get; set; }
    [Display(Name = "Ідентифікаційний номер")]
    public virtual Insuarence Insuarence { get; set; } = null!;

    public virtual Model Model { get; set; } = null!;

    public virtual Owner OwnerTinNavigation { get; set; } = null!;
}
