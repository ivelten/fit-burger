using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using FitBurger.Core.Domain.Entities.Abstractions;
using FitBurger.Core.Domain.Enums;
using FitBurger.Core.Domain.ValueObjects;

namespace FitBurger.Core.Domain.Entities;

[Display(Name = "Atendente")]
public class Attendant : Employee
{
    public Attendant(
        string name,
        PhoneNumber phoneNumber,
        Email email,
        string address, 
        Cpf cpf,
        DateOnly birthday,
        Gender gender,
        decimal salary,
        DateOnly admissionDate,
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
            salary,
            admissionDate,
            userName,
            password)
    {
        Bookings = new Collection<Booking>();
        Orders = new Collection<Order>();
    }

    protected Attendant()
    {
    }

    public virtual ICollection<Booking> Bookings { get; protected set; } = default!;

    public virtual ICollection<Order> Orders { get; protected set; } = default!;

    public override UserRole Role => UserRole.Attendant;
    
    public new void Update(
        string name,
        PhoneNumber phoneNumber,
        Email email,
        string address, 
        Cpf cpf,
        DateOnly birthday,
        Gender gender,
        decimal salary,
        DateOnly admissionDate)
    {
        base.Update(name, phoneNumber, email, address, cpf, birthday, gender, salary, admissionDate);
    }
}