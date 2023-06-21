using FitBurger.Core.Domain.Enums;

namespace FitBurger.WebApp.Models.Abstractions;

public interface IGender
{
    public Gender? Gender { get; set; }
}