using System.Reflection;

namespace FitBurger.Infrastructure;

public static class AssemblyMarker
{
    static AssemblyMarker()
    {
        Assembly = typeof(AssemblyMarker).Assembly;
    }
    
    public static Assembly Assembly { get; }
}