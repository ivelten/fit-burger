using System.Linq.Expressions;
using FitBurger.Core.Domain.Abstractions;
using FitBurger.Core.Domain.Entities;
using FitBurger.Core.Domain.Repositories.Abstractions;
using FitBurger.Core.Domain.ValueObjects;
using FitBurger.WebApp.Models.Customer;

namespace FitBurger.WebApp.Services;

public sealed class CustomerService : 
    IListService<ListCustomer>,
    ICreateService<CreateCustomer>,
    IUpdateService<UpdateCustomer>
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
            Cpf.Parse(request.Cpf!),
            DateOnly.FromDateTime(request.Birthday!.Value),
            request.Gender!.Value,
            request.UserName!,
            request.Password!);

        await _customerRepository.AddAsync(customer);
        await _unitOfWork.CommitAsync();
    }

    public async Task<ListCustomer[]> ListAsync(string? queryValue = null)
    {
        Expression<Func<Customer, bool>>? predicate =
            queryValue is not null
                ? x => x.Name.Contains(queryValue)
                : null;

        var customers = await _customerRepository.GetAsync(predicate, useFactory: true);

        return customers.Select(x => new ListCustomer
        {
            Id = x.Id,
            Name = x.Name,
            Email = x.Email,
            PhoneNumber = x.PhoneNumber,
            Birthday = x.Birthday.ToDateTime(default),
            Gender = x.Gender
        }).ToArray();
    }

    public async Task<UpdateCustomer?> GetAsync(int id)
    {
        var customer = await _customerRepository.GetAsync(id);

        if (customer is null)
            return null;

        return new UpdateCustomer
        {
            Address = customer.Address,
            Cpf = customer.Cpf,
            Email = customer.Email,
            Name = customer.Name,
            Birthday = customer.Birthday.ToDateTime(new TimeOnly()),
            Gender = customer.Gender,
            PhoneNumber = customer.PhoneNumber
        };
    }

    public async Task UpdateAsync(int id, UpdateCustomer request)
    {
        var customer = await _customerRepository.GetAsync(id);

        if (customer is null)
            return;

        customer.Update(
            request.Name!,
            PhoneNumber.Parse(request.PhoneNumber!),
            Email.Parse(request.Email!),
            request.Address!,
            Cpf.Parse(request.Cpf!),
            DateOnly.FromDateTime(request.Birthday!.Value),
            request.Gender!.Value);

        await _unitOfWork.CommitAsync();
    }
}