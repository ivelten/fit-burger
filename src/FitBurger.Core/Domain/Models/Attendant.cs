using System.Collections.ObjectModel;
using FitBurger.Core.Domain.ValueObjects;

namespace FitBurger.Core.Domain.Models;

public class Attendant
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
    }

    protected Attendant()
    {
    }

    public int Id { get; protected set; }
    
    public string Name { get; protected set; } = default!;
    
    public DateOnly Birthday { get; protected set; }

    public PhoneNumber PhoneNumber { get; protected set; } = default!;
    
    public Cpf Cpf { get; protected set; } = default!;
    
    public string Address { get; protected set; } = default!;
    
    public Gender Gender { get; protected set; }
    
    public DateOnly AdmissionDate { get; protected set; }
    
    public decimal Salary { get; protected set; }

    public virtual ICollection<Booking> Bookings { get; protected set; } = default!;
}