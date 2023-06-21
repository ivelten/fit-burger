using FitBurger.Core.Domain.Abstractions;
using FitBurger.Core.Domain.Entities;
using FitBurger.Core.Domain.Repositories.Abstractions;
using FitBurger.Core.Domain.ValueObjects;
using FitBurger.WebApp.Models.Deliveryman;

namespace FitBurger.WebApp.Services;

public class DeliverymanService : 
    IListService<ListDeliveryman>,
    ICreateService<CreateDeliveryman>,
    IUpdateService<UpdateDeliveryman>
{
    private readonly IRepository<Deliveryman> _deliverymanRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeliverymanService(
        IRepository<Deliveryman> deliverymanRepository,
        IUnitOfWork unitOfWork
        )
    {
        _deliverymanRepository = deliverymanRepository ?? throw new ArgumentNullException(nameof(deliverymanRepository));
        _unitOfWork = unitOfWork;
    }
    
    public async Task<ListDeliveryman[]> ListAsync(string? queryValue = null)
    {
        Func<Deliveryman, bool>? predicate =
            queryValue is not null
                ? x => x.Name.Contains(queryValue)
                : null;
        
        var deliverymen = await _deliverymanRepository.GetAsync(predicate);

        return deliverymen.Select(x => new ListDeliveryman
        {
            Id = x.Id,
            Name = x.Name,
            PhoneNumber = x.PhoneNumber,
            EmergencyContact = x.EmergencyContact
        }).ToArray();
    }

    public async Task CreateAsync(CreateDeliveryman request)
    {
        var deliveryman = new Deliveryman(
            request.Name!,
            PhoneNumber.Parse(request.PhoneNumber!),
            Email.Parse(request.Email!),
            request.Address!,
            Cpf.Parse(request.Cpf!),
            DateOnly.FromDateTime(request.Birthday!.Value),
            request.Gender!.Value,
            request.Salary!.Value,
            DateOnly.FromDateTime(request.AdmissionDate!.Value),
            request.EmergencyContact!,
            request.LicensePlate!,
            request.MotorcycleModel!,
            request.DrivingLicense!,
            request.UserName!,
            request.Password!);
        
        await _deliverymanRepository.AddAsync(deliveryman);
        await _unitOfWork.CommitAsync();
    }

    public async Task<UpdateDeliveryman?> GetAsync(int id)
    {
        var deliveryman = await _deliverymanRepository.GetAsync(id);

        if (deliveryman is null)
            return null;

        return new UpdateDeliveryman
        {
            Address = deliveryman.Address,
            AdmissionDate = deliveryman.AdmissionDate.ToDateTime(default),
            Birthday = deliveryman.Birthday.ToDateTime(default),
            Cpf = deliveryman.Cpf,
            Email = deliveryman.Email,
            Gender = deliveryman.Gender,
            Name = deliveryman.Name,
            PhoneNumber = deliveryman.PhoneNumber,
            Salary = deliveryman.Salary,
            EmergencyContact = deliveryman.EmergencyContact,
            LicensePlate = deliveryman.LicensePlate,
            MotorcycleModel = deliveryman.MotorcycleModel,
            DrivingLicense = deliveryman.DrivingLicense
        };
    }

    public async Task UpdateAsync(int id, UpdateDeliveryman request)
    {
        var deliveryman = await _deliverymanRepository.GetAsync(id);

        if (deliveryman is null)
            return;
        
        deliveryman.Update(
            request.Name!,
            PhoneNumber.Parse(request.PhoneNumber!),
            Email.Parse(request.Email!),
            request.Address!,
            Cpf.Parse(request.Cpf!),
            DateOnly.FromDateTime(request.Birthday!.Value),
            request.Gender!.Value,
            request.Salary!.Value,
            DateOnly.FromDateTime(request.AdmissionDate!.Value),
            request.EmergencyContact!,
            request.LicensePlate!,
            request.MotorcycleModel!,
            request.DrivingLicense!);
    }
}