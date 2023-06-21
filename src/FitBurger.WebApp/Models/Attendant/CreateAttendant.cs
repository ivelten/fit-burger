using FitBurger.WebApp.Attributes;
using FitBurger.WebApp.Models.Abstractions;

namespace FitBurger.WebApp.Models.Attendant;

[Plurality("Atendente", "Atendentes")]
public class CreateAttendant : CreateEmployee
{
}