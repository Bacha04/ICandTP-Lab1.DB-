using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace ICandTP_Lab1.DB_;

public partial class Vechicle
{
    [Required(ErrorMessage = "Поле не повинно бути порожнім!")]
    [Display(Name = "VIN Код")]
    public string Vin { get; set; } = null!;
    

    [Required(ErrorMessage = "Поле не повинно бути порожнім!")]
    [Display(Name = "Об'єм двигуна")]
    public double EngineCapacity { get; set; }


    [Display(Name = "ID моделі")]
    public int ModelId { get; set; }


    [Display(Name = "ID страхування")]
    public int InsuarenceId { get; set; }

    
    [Display(Name = "Номерний знак")]
    public string PlateNum { get; set; } = null!;

    
    [Display(Name = "Дата випуску машини")]
    public DateTime DateOfIssue { get; set; }

   
    [Display(Name = "Ідентифікаційний номер")]
    public int OwnerTin { get; set; }

    [Display(Name = "Номер страування")]
    public virtual Insuarence Insuarence { get; set; } = null!;

    [Display(Name = "Модель")]
    public virtual Model Model { get; set; } = null!;

    [Display(Name = "Ідентифікаційний номер власника")]
    public virtual Owner OwnerTinNavigation { get; set; } = null!;
}
