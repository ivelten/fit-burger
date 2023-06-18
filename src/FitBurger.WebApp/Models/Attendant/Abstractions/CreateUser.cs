using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using FitBurger.Core.Domain.Enums;
using FitBurger.WebApp.Validators;

namespace FitBurger.WebApp.Models.Attendant.Abstractions;

public class CreateUser
{
    [Required(ErrorMessage = "O nome é requerido.")]
    [StringLength(100, ErrorMessage = "O nome é muito longo. Deve ter 100 ou menos caracteres.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "A data de nascimento é requerida.")]
    [DataType(DataType.Date)]
    public DateTime? Birthday { get; set; }

    [Required(ErrorMessage = "O número de telefone é requerido.")]
    [PhoneNumber(ErrorMessage = "O telefone é inválido.")]
    public string? PhoneNumber { get; set; }
    
    [Required(ErrorMessage = "O e-mail é requerido.")]
    [Email]
    public string? Email { get; set; }

    [Required(ErrorMessage = "O CPF  é requerido.")]
    [Cpf(ErrorMessage = "O CPF é inválido.")]
    public string? Cpf { get; set; }

    [Required(ErrorMessage = "O endereço é requerido.")]
    [StringLength(200, ErrorMessage = "O endereço é muito longo. Deve ter 200 ou menos caracteres.")]
    public string? Address { get; set; }

    [Required(ErrorMessage = "O sexo é requerido.")]
    public Gender? Gender { get; set; }
    
    [Required(ErrorMessage = "O nome de usuário é requerido.")]
    public string? UserName { get; set; }
    
    [Required(ErrorMessage = "A senha é requerida.")]
    [PasswordPropertyText]
    public string? Password { get; set; }
}