using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using VxFormGenerator.Core;

namespace FitBurger.WebApp.Models.Abstractions;

public class CreateEmployee : UpdateEmployee, IUserNameAndPassword
{
    [VxIgnore]
    [Display(Name = "Nome de Usuário")]
    [Required(ErrorMessage = "O nome de usuário é requerido.")]
    public string? UserName { get; set; }
    
    [VxIgnore]
    [Display(Name = "Senha")]
    [Required(ErrorMessage = "A senha é requerida.")]
    [PasswordPropertyText]
    public string? Password { get; set; }
}