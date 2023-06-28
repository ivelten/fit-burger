using FitBurger.Core.Domain.Enums;

namespace FitBurger.WebApp.Models.Abstractions;

public interface IOrderStatus : IListModel
{
    OrderStatus Status { get; set; }
}