using System.ComponentModel.DataAnnotations;
using FitBurger.WebApp.Attributes;
using FitBurger.WebApp.Models.Abstractions;
using VxFormGenerator.Core;

namespace FitBurger.WebApp.Models.Booking;

[Plurality("Reserva", "Reservas")]
public class CreateBooking : ICustomer, IHours
{
    [VxIgnore]
    [Required(ErrorMessage = "O Cliente é requrerido.")]
    public int? CustomerId { get; set; }
    
    [Display(Name = "A partir de")]
    [Required(ErrorMessage = "A data de início é requerida.")]
    [DataType(DataType.Date)]   
    public DateTime? FromDateTime { get; set; }
    
    [VxIgnore]
    [Display(Name = "Quantidade de horas")]
    [Required(ErrorMessage = "A quantidade de horas é requerida.")]
    public TimeSpan? Hours { get; set; }
    
    [Display(Name = "Quantidade de pessoas")]
    [Required(ErrorMessage = "A quantidade de pessoas é requerida.")]
    [Range(type: typeof(int), minimum: "1", maximum: "5", ErrorMessage = "A quantidade de pessoas pode variar entre 1 e 5.")]
    public int? AmountOfPeople { get; set; }
    
    [VxIgnore]
    public int? AttendantId { get; set; }
}