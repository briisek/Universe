using System;
using System.Collections.Generic;

#nullable disable

namespace Universe.DatabaseLayer.Model
{
    public partial class Vlastnost
    {
        public Vlastnost()
        {
            VlastnostiPlanets = new HashSet<VlastnostiPlanet>();
        }

        public int Id { get; set; }
        public string Nazev { get; set; }

        public virtual ICollection<VlastnostiPlanet> VlastnostiPlanets { get; set; }
    }
}