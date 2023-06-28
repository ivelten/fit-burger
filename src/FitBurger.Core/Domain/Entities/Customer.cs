using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using FitBurger.Core.Domain.Entities.Abstractions;
using FitBurger.Core.Domain.Enums;
using FitBurger.Core.Domain.ValueObjects;

namespace FitBurger.Core.Domain.Entities;

[Display(Name = "Cliente")]
public class Customer : User
{
    public Customer(
        string name,
        PhoneNumber phoneNumber,
        Email email,
        string address, 
        Cpf cpf,
        DateOnly birthday,
        Gender gender,
        string userName,
        string password)
        : base(
            name,
            phoneNumber,
            email,
            address,
            cpf,
            birthday,
            gender,
            userName,
            password)
    {
    }

    protected Customer()
    {
    }

    public virtual ICollection<Booking> Bookings { get; protected set; } = new Collection<Booking>();

    public virtual ICollection<Order> Orders { get; protected set; } = new Collection<Order>();

    public override UserRole Role => UserRole.Customer;
    
    public new void Update(
        string name,
        PhoneNumber phoneNumber,
        Email email,
        string address, 
        Cpf cpf,
        DateOnly birthday,
        Gender gender)
    {
        base.Update(name, phoneNumber, email, address, cpf, birthday, gender);
    }
}