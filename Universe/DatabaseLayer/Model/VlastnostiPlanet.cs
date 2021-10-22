using System;
using System.Collections.Generic;

#nullable disable

namespace Universe.DatabaseLayer.Model
{
    public partial class VlastnostiPlanet
    {
        public int PlanetaId { get; set; }
        public int VlastnostId { get; set; }

        public virtual Planetum Planeta { get; set; }
        public virtual Vlastnost Vlastnost { get; set; }
    }
}
