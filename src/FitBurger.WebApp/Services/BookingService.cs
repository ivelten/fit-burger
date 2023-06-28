using System.Linq.Expressions;
using FitBurger.Core.Domain.Abstractions;
using FitBurger.Core.Domain.Entities;
using FitBurger.Core.Domain.Repositories.Abstractions;
using FitBurger.WebApp.Models.Booking;

namespace FitBurger.WebApp.Services;

public class BookingService :
    IListService<ListBooking>,
    ICreateService<CreateBooking>
{
    private readonly IRepository<Booking> _bookingRepository;
    private readonly IRepository<Customer> _customerRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly CustomAuthenticationStateProvider _websiteAuthenticator;

    public BookingService(
        IRepository<Booking> bookingRepository,
        IRepository<Customer> customerRepository,
        IUnitOfWork unitOfWork,
        CustomAuthenticationStateProvider websiteAuthenticator)
    {
        _bookingRepository = bookingRepository ?? throw new ArgumentNullException(nameof(bookingRepository));
        _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _websiteAuthenticator = websiteAuthenticator ?? throw new ArgumentNullException(nameof(websiteAuthenticator));
    }
    
    public async Task<ListBooking[]> ListAsync(string? queryValue = null)
    {
        var authenticatedUser = await _websiteAuthenticator.GetAuthenticatedUser();

        Expression<Func<Booking, bool>>? predicate = authenticatedUser?.RoleName switch
        {
            "Cliente" => booking => booking.Customer.UserName == authenticatedUser.UserName,
            _ => null
        };
        
        var bookings = await _bookingRepository.GetAsync(predicate);

        return bookings.Select(x => new ListBooking
        {
            Id = x.Id,
            AmountOfPeople = x.AmountOfPeople,
            FromDateTime = x.FromDateTime,
            ToDateTime = x.ToDateTime
        }).ToArray();
    }

    public async Task CreateAsync(CreateBooking request)
    {
        var customer = await _customerRepository.GetAsync(request.CustomerId!.Value);
        
        var booking = new Booking(
            DateTime.Now, 
            request.FromDateTime!.Value,
            request.FromDateTime.Value.Add(request.Hours!.Value),
            (byte)request.AmountOfPeople!.Value);
        
        customer!.Bookings.Add(booking);
        
        await _unitOfWork.CommitAsync();
    }
}