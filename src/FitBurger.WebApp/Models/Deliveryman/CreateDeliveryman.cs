using System.ComponentModel.DataAnnotations;
using FitBurger.WebApp.Attributes;
using FitBurger.WebApp.Models.Abstractions;

namespace FitBurger.WebApp.Models.Deliveryman;

[Plurality("Motoboy", "Motoboys")]
public class CreateDeliveryman : CreateEmployee
{
    [Display(Name = "Contato de emergência")]
    [Required(ErrorMessage = "O contato de emergência é requerido.")]
    [StringLength(200, ErrorMessage = "A descrição do contato de emergência deve ter no máximo 200 caracteres.")]
    public string? EmergencyContact { get; protected set; } = default!;

    [Display(Name = "Placa")]
    [Required(ErrorMessage = "A placa da moto é requerida.")]
    [StringLength(7, ErrorMessage = "A placa da moto deve ter no máximo 7 caracteres.")]
    public string? LicensePlate { get; protected set; } = default!;

    [Required(ErrorMessage = "O modelo da moto é requerido.")]
    [Display(Name = "Modelo da Moto")]
    [StringLength(50, ErrorMessage = "O modelo da moto deve ser descrito com no máximo 50 caracteres.")]
    public string? MotorcycleModel { get; protected set; } = default!;

    [Required(ErrorMessage = "O número da CNH é requerido.")]
    [Display(Name = "Número da CNH")]
    [StringLength(12, ErrorMessage = "O número da CNH deve ter no máximo 12 caracteres.")]
    public string? DrivingLicense { get; protected set; } = default!;
}