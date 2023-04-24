using FitBurger.Core.Domain.Abstractions;
using FitBurger.Core.Domain.Entities;
using FitBurger.Core.Domain.Repositories.Abstractions;
using FitBurger.Core.Domain.ValueObjects;
using FitBurger.WebApp.Models;

namespace FitBurger.WebApp.Services;

public sealed class CustomerService
{
    private readonly IRepository<Customer> _customerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CustomerService(IRepository<Customer> customerRepository, IUnitOfWork unitOfWork)
    {
        _customerRepository = customerRepository;
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task CreateAsync(CreateCustomer request)
    {
        var customer = new Customer(
            request.Name!,
            PhoneNumber.Parse(request.PhoneNumber!),
            Email.Parse(request.Email!),
            request.Address!,
            Cpf.Parse(request.Cpf!));

        await _customerRepository.AddAsync(customer);
        await _unitOfWork.CommitAsync();
    }

    public async Task<ListCustomer[]> ListAsync(string? queryValue = null)
    {
        Func<Customer, bool>? predicate =
            queryValue is not null
                ? x => x.Name.Contains(queryValue)
                : null;

        var customers = await _customerRepository.GetAsync(predicate);

        return customers.Select(x => new ListCustomer
        {
            Id = x.Id,
            Name = x.Name,
            Address = x.Address,
            Cpf = x.Cpf.ToString(),
            Email = x.Email.ToString(),
            PhoneNumber = x.PhoneNumber.ToString()
        }).ToArray();
    }
}