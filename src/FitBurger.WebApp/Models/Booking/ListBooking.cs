using System.ComponentModel.DataAnnotations;
using FitBurger.WebApp.Attributes;
using FitBurger.WebApp.Models.Abstractions;

namespace FitBurger.WebApp.Models.Booking;

[Plurality("Reserva", "Reservas")]
public class ListBooking : IListModel
{
    [Ignore]
    public int Id { get; set; }
    
    [Display(Name = "A partir de")]
    [DataType(DataType.DateTime)]   
    public DateTime FromDateTime { get; set; }
    
    [Display(Name = "Até")]
    [DataType(DataType.DateTime)]
    public DateTime?ToDateTime { get; set; }
    
    [Display(Name = "Quantidade de pessoas")]
    public int AmountOfPeople { get; set; }
}