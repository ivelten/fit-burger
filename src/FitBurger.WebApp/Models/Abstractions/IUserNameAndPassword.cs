namespace FitBurger.WebApp.Models.Attendant.Abstractions;

public interface IUserNameAndPassword
{
    public string? UserName { get; set; }
    
    public string? Password { get; set; }
}