namespace FitBurger.WebApp.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum | AttributeTargets.Property)]
public sealed class IgnoreAttribute : Attribute
{
}