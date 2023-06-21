using System.ComponentModel.DataAnnotations;
using FitBurger.Core.Domain.Enums;
using FitBurger.WebApp.Validators;
using VxFormGenerator.Core;

namespace FitBurger.WebApp.Models.Abstractions;

public class UpdateUser : IGender
{
    [Display(Name = "Nome")]
    [Required(ErrorMessage = "O nome é requerido.")]
    [StringLength(100, ErrorMessage = "O nome é muito longo. Deve ter 100 ou menos caracteres.")]
    public string? Name { get; set; }

    [Display(Name = "Data de Nascimento")]
    [Required(ErrorMessage = "A data de nascimento é requerida.")]
    [DataType(DataType.Date)]
    public DateTime? Birthday { get; set; }

    [Display(Name = "Telefone")]
    [Required(ErrorMessage = "O número de telefone é requerido.")]
    [PhoneNumber(ErrorMessage = "O telefone é inválido.")]
    public string? PhoneNumber { get; set; }
    
    [Display(Name = "E-mail")]
    [Required(ErrorMessage = "O e-mail é requerido.")]
    [Email]
    public string? Email { get; set; }

    [Display(Name = "CPF")]
    [Required(ErrorMessage = "O CPF  é requerido.")]
    [Cpf(ErrorMessage = "O CPF é inválido.")]
    public string? Cpf { get; set; }

    [Display(Name = "Endereço")]
    [Required(ErrorMessage = "O endereço é requerido.")]
    [StringLength(200, ErrorMessage = "O endereço é muito longo. Deve ter 200 ou menos caracteres.")]
    public string? Address { get; set; }

    [VxIgnore]
    [Display(Name = "Sexo")]
    [Required(ErrorMessage = "O sexo é requerido.")]
    public Gender? Gender { get; set; }
}