using System;
using System.Collections;
using System.Linq;

using LinqToDB.DataProvider.SqlServer;
using LinqToDB.Mapping;

namespace Universe.Entities
{
    [Table("VlastnostiPlanet")]
    public class VlastnostiPlanet
    {
        [PrimaryKey, Identity]
        public int PlanetaId { get; set; }

        [PrimaryKey, Identity]
        public int VlastnostId { get; set; }

        public virtual Planetum Planeta { get; set; }
        public virtual Vlastnost Vlastnost { get; set; }
    }
}