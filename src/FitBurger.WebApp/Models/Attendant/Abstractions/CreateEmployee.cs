using System.ComponentModel.DataAnnotations;

namespace FitBurger.WebApp.Models.Attendant.Abstractions;

public class CreateEmployee : CreateUser
{
    [Required(ErrorMessage = "A data de admissão é requerida.")]
    [DataType(DataType.Date)]
    public DateTime? AdmissionDate { get; set; }

    [Required(ErrorMessage = "O salário é requerido.")]
    [RegularExpression(@"\d+(\,\d{1,2})?",
        ErrorMessage = "Salário inválido. Precisa ser um número decimal com duas casas.")]
    public decimal? Salary { get; set; }
}