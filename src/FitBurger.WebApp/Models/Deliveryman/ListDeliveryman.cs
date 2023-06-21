using System.ComponentModel.DataAnnotations;
using FitBurger.WebApp.Attributes;
using FitBurger.WebApp.Models.Abstractions;

namespace FitBurger.WebApp.Models.Deliveryman;

[Plurality("Motoboy", "Motoboys")]
public class ListDeliveryman : IListModel
{
    public int Id { get; init; }
    
    [Display(Name = "Nome")]
    public string? Name { get; init; }
    
    [Display(Name = "Telefone")]
    public string? PhoneNumber { get; init; }
    
    [Display(Name = "Contato de emergência")]
    public string? EmergencyContact { get; init; }
}