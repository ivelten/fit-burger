using System.ComponentModel.DataAnnotations;
using FitBurger.Core.Domain.ValueObjects;
using FitBurger.WebApp.Validators;

namespace FitBurger.WebApp.Models.Attendant;

public class CreateAttendant
{
    [Required(ErrorMessage = "O nome é requerido.")]
    [StringLength(100, ErrorMessage = "O nome é muito longo. Deve ter 100 ou menos caracteres.")]
    public string? Name { get;  set; }
    
    [Required(ErrorMessage = "A data de nascimento é requerida.")]
    [DataType(DataType.Date)]
    public DateTime? Birthday { get; set; }

    [Required(ErrorMessage = "O número de telefone é requerido.")]
    [PhoneNumber(ErrorMessage = "O telefone é inválido.")]
    public string? PhoneNumber { get; set; }
    
    [Required(ErrorMessage = "O CPF  é requerido.")]
    [Cpf(ErrorMessage = "O CPF é inválido.")]
    public string? Cpf { get; set; }
    
    [Required(ErrorMessage = "O endereço é requerido.")]
    [StringLength(200, ErrorMessage = "O endereço é muito longo. Deve ter 200 ou menos caracteres.")]
    public string? Address { get; set; }
    
    [Required(ErrorMessage = "O sexo é requerido.")]
    public Gender? Gender { get; set; }
    
    [Required(ErrorMessage = "A data de admissão é requerida.")]
    [DataType(DataType.Date)]
    public DateTime? AdmissionDate { get; set; }
    
    [Required(ErrorMessage = "O salário é requerido.")]
    [RegularExpression(@"\d+(\,\d{1,2})?", ErrorMessage = "Salário inválido. Precisa ser um número decimal com duas casas.")]
    public decimal? Salary { get; set; }
}