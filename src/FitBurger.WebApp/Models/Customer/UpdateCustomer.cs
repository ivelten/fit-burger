using FitBurger.WebApp.Attributes;
using FitBurger.WebApp.Models.Abstractions;

namespace FitBurger.WebApp.Models.Customer;

[Plurality("Cliente", "Clientes")]
public sealed class UpdateCustomer : UpdateUser
{
}