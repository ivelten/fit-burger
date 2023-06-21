using System.ComponentModel.DataAnnotations;
using FitBurger.Core.Domain.Enums;
using FitBurger.WebApp.Attributes;
using FitBurger.WebApp.Models.Abstractions;

namespace FitBurger.WebApp.Models.Customer;

[Plurality("Cliente", "Clientes")]
public class ListCustomer : IListModel
{
    [Ignore]
    public int Id { get; init; }

    [Display(Name = "Nome")]
    public string? Name { get; init; }

    [Display(Name = "Data de Nascimento")]
    [DataType(DataType.Date)]
    public DateTime? Birthday { get; init; }
    
    [Display(Name = "Telefone")]
    public string? PhoneNumber { get; init; }

    [Display(Name = "e-mail")]
    public string? Email { get; init; }

    [Display(Name = "Sexo")]
    public Gender? Gender { get; init; }
}