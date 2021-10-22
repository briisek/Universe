using System;
using System.Collections.Generic;

#nullable disable

namespace Universe.DatabaseLayer.Model
{
    public partial class Planetum
    {
        public Planetum()
        {
            VlastnostiPlanets = new HashSet<VlastnostiPlanet>();
        }

        public int Id { get; set; }
        public string Jmeno { get; set; }
        public int? Velikost { get; set; }
        public int GalaxieId { get; set; }
        public Guid? Identifikator { get; set; }

        public virtual Galaxie Galaxie { get; set; }
        public virtual ICollection<VlastnostiPlanet> VlastnostiPlanets { get; set; }
    }
}
