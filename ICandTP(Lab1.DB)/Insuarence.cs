using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace ICandTP_Lab1.DB_;

public partial class Insuarence
{
    public int Id { get; set; }


    [Required(ErrorMessage = "Поле не повинно бути порожнім!")]
    [Display(Name = "Дата видачі")]
    public DateTime IssueDate { get; set; }


    [Required(ErrorMessage = "Поле не повинно бути порожнім!")]
    [Display(Name = "Дійсне до:")]
    public DateTime ExpirationDate { get; set; }


    [Required(ErrorMessage = "Поле не повинно бути порожнім!")]
    [Display(Name = "VIN код транспортного засобу")]
    public string VechicleVin { get; set; } = null!;


    [Required(ErrorMessage = "Поле не повинно бути порожнім!")]
    [Display(Name = "Тип кузова")]
    public string Type { get; set; } = null!;

    public virtual ICollection<Vechicle> Vechicles { get; } = new List<Vechicle>();
}
