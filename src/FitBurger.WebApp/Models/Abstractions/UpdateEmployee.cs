using System.ComponentModel.DataAnnotations;

namespace FitBurger.WebApp.Models.Abstractions;

public class UpdateEmployee : UpdateUser
{
    [Display(Name = "Data de admissão")]
    [Required(ErrorMessage = "A data de admissão é requerida.")]
    [DataType(DataType.Date)]
    public DateTime? AdmissionDate { get; set; }

    [Display(Name = "Salário")]
    [Required(ErrorMessage = "O salário é requerido.")]
    [RegularExpression(@"\d+(\,\d{1,2})?",
        ErrorMessage = "Salário inválido. Precisa ser um número decimal com duas casas.")]
    public decimal? Salary { get; set; }
}