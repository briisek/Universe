using System;
using System.Collections;
using System.Linq;

using LinqToDB.DataProvider.SqlServer;
using LinqToDB.Mapping;

namespace Universe.Entities
{
    [Table("Planetum")]
    public class Planetum
    {
        public int Id { get; set; }
        public string Jmeno { get; set; }
        public int? Velikost { get; set; }
        public int GalaxieId { get; set; }
        public Guid? Identifikator { get; set; }

        public virtual Galaxie Galaxie { get; set; }
    }
}