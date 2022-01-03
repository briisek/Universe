using System;
using Universe.Entities;

namespace Universe.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            UniverseContext universeContext = new UniverseContext();
            universeContext.ListPlanetProperties();
        }
    }
}