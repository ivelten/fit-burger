using FitBurger.Core.Domain.Abstractions;
using FitBurger.Core.Domain.Entities;
using FitBurger.Core.Domain.Repositories.Abstractions;
using FitBurger.WebApp.Models.Order;

namespace FitBurger.WebApp.Services;

public class OrderService : ICreateService<CreateOrder>
{
	private readonly IRepository<Order> _orderRepository;
	private readonly IRepository<Product> _productRepository;
	private readonly IRepository<Customer> _customerRepository;
	private readonly IUnitOfWork _unitOfWork;

	public OrderService(
		IRepository<Order> orderRepository,
		IRepository<Product> productRepository,
		IRepository<Customer> customerRepository,
		IUnitOfWork unitOfWork)
	{
		_orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
		_productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
		_customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
		_unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
	}

	public async Task CreateAsync(CreateOrder request)
	{
		var customer = await _customerRepository.GetAsync(request.CustomerId);

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
}