using System.ComponentModel.DataAnnotations;
using FitBurger.WebApp.Attributes;
using FitBurger.WebApp.Models.Abstractions;

namespace FitBurger.WebApp.Models.Deliveryman;

[Plurality("Motoboy", "Motoboys")]
public class UpdateDeliveryman : UpdateEmployee
{
    [Display(Name = "Contato de emergência")]
    [Required(ErrorMessage = "O contato de emergência é requerido.")]
    public string? EmergencyContact { get; set; } = default!;

    [Display(Name = "Placa")]
    [Required(ErrorMessage = "A placa da moto é requerida.")]
    public string? LicensePlate { get; set; } = default!;

    [Required(ErrorMessage = "O modelo da moto é requerido.")]
    [Display(Name = "Modelo da Moto")]
    public string? MotorcycleModel { get; set; } = default!;

    [Required(ErrorMessage = "O número da CNH é requerido.")]
    [Display(Name = "Número da CNH")]
    public string? DrivingLicense { get; set; } = default!;
}