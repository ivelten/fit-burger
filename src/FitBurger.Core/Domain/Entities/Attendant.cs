using System.Collections.ObjectModel;
using FitBurger.Core.Domain.ValueObjects;

namespace FitBurger.Core.Domain.Entities;

public class Attendant : EntityWithId
{
    public Attendant(
        string name,
        DateOnly birthday,
        PhoneNumber phoneNumber,
        Cpf cpf,
        string address,
        Gender gender,
        DateOnly admissionDate,
        decimal salary)
    {
        Name = name;
        Birthday = birthday;
        PhoneNumber = phoneNumber;
        Cpf = cpf;
        Address = address;
        Gender = gender;
        AdmissionDate = admissionDate;
        Salary = salary;
        Bookings = new Collection<Booking>();
        Orders = new Collection<Order>();
    }

    protected Attendant()
    {
    }

    public void Update(string name,
        DateOnly birthday,
        PhoneNumber phoneNumber,
        Cpf cpf,
        string address,
        Gender gender,
        DateOnly admissionDate,
        decimal salary)
    {
        Name = name;
        Birthday = birthday;
        PhoneNumber = phoneNumber;
        Cpf = cpf;
        Address = address;
        Gender = gender;
        AdmissionDate = admissionDate;
        Salary = salary;
    }

    public string Name { get;  set; } = default!;
    
    public DateOnly Birthday { get; protected set; }

    public PhoneNumber PhoneNumber { get; protected set; } = default!;
    
    public Cpf Cpf { get; protected set; } = default!;
    
    public string Address { get; protected set; } = default!;
    
    public Gender Gender { get; protected set; }
    
    public DateOnly AdmissionDate { get; protected set; }
    
    public decimal Salary { get; protected set; }

    public virtual ICollection<Booking> Bookings { get; protected set; } = default!;

    public virtual ICollection<Order> Orders { get; protected set; } = default!;
}