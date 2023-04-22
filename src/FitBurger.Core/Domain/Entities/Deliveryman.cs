using System.Collections.ObjectModel;
using FitBurger.Core.Domain.ValueObjects;

namespace FitBurger.Core.Domain.Entities;

public class Deliveryman
{
    public Deliveryman(
        string name,
        PhoneNumber phoneNumber, 
        string emergencyContact, 
        string licensePlate, 
        string motorcycleModel,
        string drivingLicense, 
        Gender gender)
    {
        Name = name;
        PhoneNumber = phoneNumber;
        EmergencyContact = emergencyContact;
        LicensePlate = licensePlate;
        MotorcycleModel = motorcycleModel;
        DrivingLicense = drivingLicense;
        Gender = gender;
        Orders = new Collection<Order>();
    }

    protected Deliveryman()
    {
    }

    public int Id { get; protected set; }

    public string Name { get; protected set; } = default!;

    public PhoneNumber PhoneNumber { get; protected set; } = default!;

    public string EmergencyContact { get; protected set; } = default!;

    public string LicensePlate { get; protected set; } = default!;

    public string MotorcycleModel { get; protected set; } = default!;

    public string DrivingLicense { get; protected set; } = default!;
    
    public Gender Gender { get; protected set; }

    public virtual ICollection<Order> Orders { get; protected set; } = default!;
}