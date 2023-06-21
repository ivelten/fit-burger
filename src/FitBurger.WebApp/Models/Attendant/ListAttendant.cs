using System.ComponentModel.DataAnnotations;
using FitBurger.Core.Domain.Enums;
using FitBurger.WebApp.Attributes;
using FitBurger.WebApp.Models.Attendant.Abstractions;

namespace FitBurger.WebApp.Models.Attendant;

[Plurality("Atendente", "Atendentes")]
public sealed class ListAttendant : IListModel
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

    [Display(Name = "Sexo")]
    public Gender? Gender { get; init; }
}