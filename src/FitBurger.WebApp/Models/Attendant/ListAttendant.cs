using FitBurger.Core.Domain.Enums;

namespace FitBurger.WebApp.Models.Attendant;

public sealed class ListAttendant
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public DateTime? Birthday { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Cpf { get; set; }

    public string? Address { get; set; }

    public Gender? Gender { get; set; }

    public DateTime? AdmissionDate { get; set; }

    public decimal? Salary { get; set; }
}