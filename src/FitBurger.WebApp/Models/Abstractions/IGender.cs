using FitBurger.Core.Domain.Enums;

namespace FitBurger.WebApp.Models.Attendant.Abstractions;

public interface IGender
{
    public Gender? Gender { get; set; }
}