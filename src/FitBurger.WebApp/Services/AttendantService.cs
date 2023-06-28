using System.Linq.Expressions;
using FitBurger.Core.Domain.Abstractions;
using FitBurger.Core.Domain.Entities;
using FitBurger.Core.Domain.Repositories.Abstractions;
using FitBurger.Core.Domain.ValueObjects;
using FitBurger.WebApp.Models.Attendant;

namespace FitBurger.WebApp.Services;

public sealed class AttendantService : 
    IListService<ListAttendant>,
    ICreateService<CreateAttendant>,
    IUpdateService<UpdateAttendant>
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
            PhoneNumber.Parse(request.PhoneNumber!),
            Email.Parse(request.Email!),
            request.Address!,
            Cpf.Parse(request.Cpf!),
            DateOnly.FromDateTime(request.Birthday!.Value),
            request.Gender!.Value,
            request.Salary!.Value,
            DateOnly.FromDateTime(request.AdmissionDate!.Value),
            request.UserName!,
            request.Password!);

        await _attendantRepository.AddAsync(attendant);
        await _unitOfWork.CommitAsync();
    }

    public async Task<ListAttendant[]> ListAsync(string? queryValue = null)
    {
        Expression<Func<Attendant, bool>>? predicate =
            queryValue is not null
                ? x => x.Name.Contains(queryValue)
                : null;

        var attendants = await _attendantRepository.GetAsync(predicate, useFactory: true);

        return attendants.Select(x => new ListAttendant
        {
            Id = x.Id,
            Name = x.Name,
            Birthday = x.Birthday.ToDateTime(default),
            PhoneNumber = x.PhoneNumber,
            Gender = x.Gender,
            Email = x.Email
        }).ToArray();
    }

    public async Task<UpdateAttendant?> GetAsync(int id)
    {
        var attendant = await _attendantRepository.GetAsync(id);

        if (attendant is null)
            return null;

        return new UpdateAttendant
        {
            Name = attendant.Name,
            Birthday = attendant.Birthday.ToDateTime(default),
            PhoneNumber = attendant.PhoneNumber,
            Email = attendant.Email,
            Cpf = attendant.Cpf,
            Address = attendant.Address,
            Gender = attendant.Gender,
            AdmissionDate = attendant.AdmissionDate.ToDateTime(default),
            Salary = attendant.Salary
        };
    }

    public async Task UpdateAsync(int id, UpdateAttendant request)
    {
        var attendant = await _attendantRepository.GetAsync(id);

        if (attendant is null)
            return;

        attendant.Update(
            request.Name!,
            PhoneNumber.Parse(request.PhoneNumber!),
            Email.Parse(request.Email!),
            request.Address!,
            Cpf.Parse(request.Cpf!),
            DateOnly.FromDateTime(request.Birthday!.Value),
            request.Gender!.Value,
            request.Salary!.Value,
            DateOnly.FromDateTime(request.AdmissionDate!.Value));

        await _unitOfWork.CommitAsync();
    }
}