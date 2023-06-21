using FitBurger.Core.Domain.Enums;
using FitBurger.Core.Domain.ValueObjects;

namespace FitBurger.Core.Domain.Entities.Abstractions;

public abstract class Employee : User
{
    protected Employee(
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
            userName,
            password)
    {
        Salary = salary;
        AdmissionDate = admissionDate;
    }

    protected Employee()
    {
    }
    
    public decimal Salary { get; protected set; }
    
    public DateOnly AdmissionDate { get; protected set; }

    protected void Update(
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
        base.Update(name, phoneNumber, email, address, cpf, birthday, gender);

        Salary = salary;
        AdmissionDate = admissionDate;
    }
}