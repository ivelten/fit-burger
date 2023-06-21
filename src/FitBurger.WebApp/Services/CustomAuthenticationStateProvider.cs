using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Security.Claims;
using System.Text.Json;
using FitBurger.Core.Domain.Entities.Abstractions;
using FitBurger.Core.Domain.Repositories.Abstractions;
using FitBurger.WebApp.Models.User;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace FitBurger.WebApp.Services;

public sealed class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly IUserRepository _userRepository;
    private readonly ProtectedLocalStorage _localStorage;

    public const string StorageKey = "identity";

    public CustomAuthenticationStateProvider(
        IUserRepository userRepository,
        ProtectedLocalStorage localStorage)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _localStorage = localStorage ?? throw new ArgumentNullException(nameof(localStorage));
    }
    
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var principal = new ClaimsPrincipal();

        try
        {
            var storedPrincipal = await _localStorage.GetAsync<string>(StorageKey);

            if (storedPrincipal is { Success: true, Value: not null })
            {
                var user = JsonSerializer.Deserialize<AuthenticatedUser>(storedPrincipal.Value);

                if (user is not null)
                {
                    var databaseUser = await _userRepository.GetByUserNameAsync(user.UserName);

                    if (databaseUser is not null && user.PasswordHash == databaseUser.PasswordHash)
                    {
                        var identity = CreateIdentityFromUser(databaseUser);

                        principal = new ClaimsPrincipal(identity);
                    }
                }
            }
        }
        catch
        {
        }
        
        return new AuthenticationState(principal);
    }

    private static ClaimsIdentity CreateIdentityFromUser(User user)
    {
        var roleName = user.GetType().GetCustomAttribute<DisplayAttribute>()!.Name!;
        
        var claims = new Claim[]
        {
            new(ClaimTypes.Name, user.Name),
            new(ClaimTypes.Hash, user.PasswordHash),
            new(ClaimTypes.Role, roleName)
        };

        return new ClaimsIdentity(claims, authenticationType: "FitBurgerAuth");
    }

    public async Task<AuthenticatedUser?> GetAuthenticatedUser()
    {
        var storedPrincipal = await _localStorage.GetAsync<string>(StorageKey);

        if (storedPrincipal.Value is null)
            return null;
        
        return JsonSerializer.Deserialize<AuthenticatedUser>(storedPrincipal.Value);
    }

    public async Task<bool> LoginAsync(LoginFormModel loginFormModel)
    {
        var principal = new ClaimsPrincipal();
        var databaseUser = await _userRepository.GetByUserNameAsync(loginFormModel.UserName);

        if (databaseUser is not null && BCrypt.Net.BCrypt.Verify(loginFormModel.Password, databaseUser.PasswordHash))
        {
            var identity = CreateIdentityFromUser(databaseUser);
            var role = identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role);
            
            var user = new AuthenticatedUser(
                databaseUser.Name,
                databaseUser.UserName, 
                databaseUser.PasswordHash,
                databaseUser.PhoneNumber,
                databaseUser.Email,
                role!.Value);

            principal = new ClaimsPrincipal(identity);

            var userSerialized = JsonSerializer.Serialize(user);
            
            await _localStorage.SetAsync(StorageKey, userSerialized);
        }

        var state = new AuthenticationState(principal);

        NotifyAuthenticationStateChanged(Task.FromResult(state));

        return databaseUser is not null;
    }

    public async Task LogoutAsync()
    {
        await _localStorage.DeleteAsync(StorageKey);

        var principal = new ClaimsPrincipal();
        var state = new AuthenticationState(principal);
        
        NotifyAuthenticationStateChanged(Task.FromResult(state));
    }
}