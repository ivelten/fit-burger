using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using VxFormGenerator.Core;

namespace FitBurger.WebApp.Models.Abstractions;

public class CreateUser : UpdateUser, IUserNameAndPassword
{
    [VxIgnore]
    [Display(Name = "Nome de Usuário")]
    [Required(ErrorMessage = "O nome de usuário é requerido.")]
    [StringLength(256, ErrorMessage = "O nome de usuário não deve ultrapassar 256 caracteres.")]
    public string? UserName { get; set; }
    
    [VxIgnore]
    [Display(Name = "Senha")]
    [Required(ErrorMessage = "A senha é requerida.")]
    [StringLength(256, ErrorMessage = "A senha não deve ultrapassar 256 caracteres.")]
    [PasswordPropertyText]
    public string? Password { get; set; }
}