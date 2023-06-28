using System.Linq.Expressions;
using FitBurger.Core.Domain.Abstractions;
using FitBurger.Core.Domain.Entities;
using FitBurger.Core.Domain.Enums;
using FitBurger.Core.Domain.Repositories.Abstractions;
using FitBurger.WebApp.Models.Order;

namespace FitBurger.WebApp.Services;

public class OrderService : 
	ICreateService<CreateOrder>,
	IListService<ListOrder>
{
	private readonly CustomAuthenticationStateProvider _websiteAuthenticator;
	private readonly IRepository<Order> _orderRepository;
	private readonly IRepository<Product> _productRepository;
	private readonly IRepository<Customer> _customerRepository;
	private readonly IUnitOfWork _unitOfWork;

	public OrderService(
		CustomAuthenticationStateProvider websiteAuthenticator,
		IRepository<Order> orderRepository,
		IRepository<Product> productRepository,
		IRepository<Customer> customerRepository,
		IUnitOfWork unitOfWork)
	{
		_websiteAuthenticator = websiteAuthenticator ?? throw new ArgumentNullException(nameof(websiteAuthenticator));
		_orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
		_productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
		_customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
		_unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
	}

	public async Task CreateAsync(CreateOrder request)
	{
		var customer = await _customerRepository.GetAsync(request.CustomerId!.Value);

		var order = new Order(
			request.Street!,
			request.Number!,
			request.District!,
			request.Cep!,
			request.ShouldDeliver);
		
		customer!.Orders.Add(order);

		foreach (var orderItemRequest in request.Items!)
		{
			var product = await _productRepository.GetAsync(orderItemRequest.ProductId!.Value);

			order.Items.Add(new OrderItem(product!, orderItemRequest.Quantity!.Value));
		}

		foreach (var orderPayment in request.Payments!)
		{
			order.Payments.Add(new OrderPayment(orderPayment.Method!.Value, orderPayment.Amount!.Value));
		}
		
		await _unitOfWork.CommitAsync();
	}

	public async Task<ListOrder[]> ListAsync(string? queryValue = null)
	{
		var authenticatedUser = await _websiteAuthenticator.GetAuthenticatedUser();
		Expression<Func<Order, bool>>? predicate = null;

		if (authenticatedUser is not null)
		{
			predicate = authenticatedUser.RoleName switch
			{
				"Cliente" => order => 
					order.Customer.UserName == authenticatedUser.UserName && order.Status != OrderStatus.Canceled,
				
				"Motoboy" => order =>
					order.Deliveryman == null || order.Deliveryman.UserName == authenticatedUser.UserName,
				
				_ => predicate
			};
		}
		
		var orders = await _orderRepository.GetAsync(predicate);

		return orders.Select(x => new ListOrder
		{
			CustomerId = x.Customer.Id,
			CustomerName = x.Customer.Name,
			DeliverymanName = x.Deliveryman?.Name,
			Id = x.Id,
			ShouldDeliver = x.ShouldDelivery,
			Status = x.Status
		}).ToArray();
	}
}