using System.ComponentModel.DataAnnotations;
using FitBurger.Core.Domain.Enums;
using FitBurger.Core.Domain.ValueObjects;

namespace FitBurger.Core.Domain.Entities.Abstractions;

[Display(Name = "Administrador")]
public abstract class User : Entity
{
    protected User(
        string name,
        PhoneNumber phoneNumber,
        Email email,
        string address, 
        Cpf cpf,
        DateOnly birthday,
        Gender gender,
        string userName,
        string password)
    {
        Name = name;
        PhoneNumber = phoneNumber;
        Email = email;
        Address = address;
        Cpf = cpf;
        Birthday = birthday;
        Gender = gender;
        UserName = userName;
        
        PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
    }

    protected User()
    {
    }

    public string Name { get; protected set; } = default!;

    public PhoneNumber PhoneNumber { get; protected set; } = default!;

    public Email Email { get; protected set; } = default!;

    public string Address { get; protected set; } = default!;

    public Cpf Cpf { get; protected set; } = default!;
    
    public DateOnly Birthday { get; protected set; }
    
    public Gender Gender { get; protected set; }

    public string UserName { get; protected set; } = default!;

    public string PasswordHash { get; protected set; } = default!;
    
    public abstract UserRole Role { get; }

    protected void Update(
        string name,
        PhoneNumber phoneNumber,
        Email email,
        string address,
        Cpf cpf,
        DateOnly birthday,
        Gender gender)
    {
        Name = name;
        PhoneNumber = phoneNumber;
        Email = email;
        Address = address;
        Cpf = cpf;
        Birthday = birthday;
        Gender = gender;
    }
}