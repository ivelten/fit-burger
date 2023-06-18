using FitBurger.Core.Domain.Entities.Abstractions;
using FitBurger.Core.Domain.ValueObjects;

namespace FitBurger.Core.Domain.Entities;

public class User : EntityWithId
{
    public User(
        string name,
        PhoneNumber phoneNumber,
        Email email, string
            address, Cpf cpf,
        string userName,
        string passwordHash)
    {
        Name = name;
        PhoneNumber = phoneNumber;
        Email = email;
        Address = address;
        Cpf = cpf;
        UserName = userName;
        PasswordHash = passwordHash;
    }

    protected User()
    {
    }

    public string Name { get; protected set; } = default!;

    public PhoneNumber PhoneNumber { get; protected set; } = default!;

    public Email Email { get; protected set; } = default!;

    public string Address { get; protected set; } = default!;

    public Cpf Cpf { get; protected set; } = default!;

    public string UserName { get; protected set; } = default!;

    public string PasswordHash { get; protected set; } = default!;
}