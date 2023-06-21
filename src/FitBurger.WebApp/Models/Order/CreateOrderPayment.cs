using System.ComponentModel.DataAnnotations;
using FitBurger.Core.Domain.ValueObjects;

namespace FitBurger.WebApp.Models.Order;

public class CreateOrderPayment
{
    [Display(Name = "Meio de pagamento")]
    [Required(ErrorMessage = "O meio de pagamento é requerido.")]
    public PaymentMethod? Method { get; set; }

    [Display(Name = "Valor")]
    [Required(ErrorMessage = "O valor é requerido.")]
    [Range(0, int.MaxValue, ErrorMessage = "O valor deve ser maior que 0 e menor que 2147483647.")]
    public decimal? Amount { get; set; }
}