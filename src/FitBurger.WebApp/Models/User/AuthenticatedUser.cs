namespace FitBurger.WebApp.Models.User;

public class AuthenticatedUser
{
    public AuthenticatedUser(
        string name,
        string userName,
        string passwordHash, 
        string phoneNumber,
        string email,
        string roleName)
    {
        Name = name;
        UserName = userName;
        PasswordHash = passwordHash;
        PhoneNumber = phoneNumber;
        Email = email;
        RoleName = roleName;
    }

    protected AuthenticatedUser()
    {
    }

    public string Name { get; set; } = default!;
    
    public string UserName { get; init; } = default!;

    public string PasswordHash { get; init; } = default!;
    
    public string PhoneNumber { get; protected set; } = default!;

    public string Email { get; protected set; } = default!;

    public string RoleName { get; set; } = default!;
}