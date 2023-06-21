using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FitBurger.WebApp.Models.User;

public class LoginFormModel
{
    [Description("Nome de usuário")]
    [Required(ErrorMessage = "O nome do usuário é requerido.")]
    public string UserName { get; set; } = default!;

    [Description("Senha")]
    [Required(ErrorMessage = "A senha é requerida.")]
    public string Password { get; set; } = default!;
}