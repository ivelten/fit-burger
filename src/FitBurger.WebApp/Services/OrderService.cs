using FitBurger.Core.Domain.Abstractions;
using FitBurger.Core.Domain.Entities;
using FitBurger.Core.Domain.Repositories.Abstractions;
using FitBurger.WebApp.Models.Order;

namespace FitBurger.WebApp.Services;

public class OrderService : ICreateService<CreateOrder>
	{
		private readonly IRepository<Order> _orderRepository;
		private readonly IUnitOfWork _unitOfWork;

		public OrderService(
			IRepository<Order> orderRepository,
			IUnitOfWork unitOfWork)
		{
			_orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
			_unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
		}

		public async Task CreateAsync(CreateOrder request)
		{
			var order = new Order(
				request.DeliveryAddress!);

			await _orderRepository.AddAsync(order);
			await _unitOfWork.CommitAsync();
		}
	}

