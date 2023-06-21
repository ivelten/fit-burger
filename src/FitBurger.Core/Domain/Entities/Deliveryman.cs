using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using FitBurger.Core.Domain.Entities.Abstractions;
using FitBurger.Core.Domain.Enums;
using FitBurger.Core.Domain.ValueObjects;

namespace FitBurger.Core.Domain.Entities;

[Display(Name = "Motoboy")]
public class Deliveryman : Employee
{
    public Deliveryman(
        string name,
        PhoneNumber phoneNumber,
        Email email,
        string address, 
        Cpf cpf,
        DateOnly birthday,
        Gender gender,
        decimal salary,
        DateOnly admissionDate,
        string emergencyContact,
        string licensePlate,
        string motorcycleModel,
        string drivingLicense,
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
        EmergencyContact = emergencyContact;
        LicensePlate = licensePlate;
        MotorcycleModel = motorcycleModel;
        DrivingLicense = drivingLicense;
        
        Orders = new Collection<Order>();
    }

    protected Deliveryman()
    {
    }

    public string EmergencyContact { get; protected set; } = default!;

    public string LicensePlate { get; protected set; } = default!;

    public string MotorcycleModel { get; protected set; } = default!;

    public string DrivingLicense { get; protected set; } = default!;

    public virtual ICollection<Order> Orders { get; protected set; } = default!;
    
    public void Update(
        string name,
        PhoneNumber phoneNumber,
        Email email,
        string address, 
        Cpf cpf,
        DateOnly birthday,
        Gender gender,
        decimal salary,
        DateOnly admissionDate,
        string emergencyContact,
        string licensePlate,
        string motorcycleModel,
        string drivingLicense)
    {
        base.Update(name, phoneNumber, email, address, cpf, birthday, gender, salary, admissionDate);
        
        EmergencyContact = emergencyContact;
        LicensePlate = licensePlate;
        MotorcycleModel = motorcycleModel;
        DrivingLicense = drivingLicense;
    }

    public override UserRole Role => UserRole.Deliveryman;
}