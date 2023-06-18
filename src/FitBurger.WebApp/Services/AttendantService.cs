using FitBurger.Core.Domain.Abstractions;
using FitBurger.Core.Domain.Entities;
using FitBurger.Core.Domain.Repositories.Abstractions;
using FitBurger.Core.Domain.ValueObjects;
using FitBurger.WebApp.Models.Attendant;

namespace FitBurger.WebApp.Services;

public sealed class AttendantService
{
    private readonly IRepository<Attendant> _attendantRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AttendantService(IRepository<Attendant> customerRepository, IUnitOfWork unitOfWork)
    {
        _attendantRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task CreateAsync(CreateAttendant request)
    {
        var attendant = new Attendant(
            request.Name!,
            DateOnly.FromDateTime(request.Birthday!.Value),
            PhoneNumber.Parse(request.PhoneNumber!),
            Cpf.Parse(request.Cpf!),
            request.Address!,
            request.Gender!.Value,
            DateOnly.FromDateTime(request.AdmissionDate!.Value),
            request.Salary!.Value);

        await _attendantRepository.AddAsync(attendant);
        await _unitOfWork.CommitAsync();
    }

    public async Task<ListAttendant[]> ListAsync(string? queryValue = null)
    {
        Func<Attendant, bool>? predicate =
            queryValue is not null
                ? x => x.Name.Contains(queryValue)
                : null;

        var attendants = await _attendantRepository.GetAsync(predicate);

        return attendants.Select(x => new ListAttendant
        {
            Id = x.Id,
            Name = x.Name,
            Birthday = x.Birthday.ToDateTime(new TimeOnly()),
            PhoneNumber = x.PhoneNumber.ToString(),
            Cpf = x.Cpf.ToString(),
            Address = x.Address,
            Gender = x.Gender,
            AdmissionDate = x.AdmissionDate.ToDateTime(new TimeOnly()),
            Salary = x.Salary
        }).ToArray();
    }

    public async Task<UpdateAttendant?> GetAsync(int id)
    {
        var attendant = await _attendantRepository.GetAsync(id);

        if (attendant is null)
            return null;

        return new UpdateAttendant
        {
            Id = attendant.Id,
            Name = attendant.Name,
            Birthday = attendant.Birthday.ToDateTime(new TimeOnly()),
            PhoneNumber = attendant.PhoneNumber.ToString(),
            Cpf = attendant.Cpf.ToString(),
            Address = attendant.Address,
            Gender = attendant.Gender,
            AdmissionDate = attendant.AdmissionDate.ToDateTime(new TimeOnly()),
            Salary = attendant.Salary
        };
    }

    public async Task UpdateAsync(UpdateAttendant request)
    {
        var attendant = await _attendantRepository.GetAsync(request.Id);

        if (attendant is null)
            return;

        attendant.Update(
            request.Name!,
            DateOnly.FromDateTime(request.Birthday!.Value),
            PhoneNumber.Parse(request.PhoneNumber!),
            Cpf.Parse(request.Cpf!),
            request.Address!,
            request.Gender!.Value,
            DateOnly.FromDateTime(request.AdmissionDate!.Value),
            request.Salary!.Value);

        await _unitOfWork.CommitAsync();
    }
}