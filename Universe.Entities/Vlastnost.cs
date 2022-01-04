using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB.DataProvider.SqlServer;
using LinqToDB.Mapping;

namespace Universe.Entities
{
    [Table("Vlastnost")]
    public class Vlastnost
    {
        public Vlastnost()
        {
            VlastnostiPlanets = new HashSet<VlastnostiPlanet>();
        }
        
        [PrimaryKey, Identity]
        public int Id { get; set; }
        
        [Column, Nullable]
        public string Nazev { get; set; }
        
        private ICollection<VlastnostiPlanet> VlastnostiPlanets { get; set; }
    }
}