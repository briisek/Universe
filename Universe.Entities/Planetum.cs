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
        [PrimaryKey]
        public int Id { get; set; }
        
        [Column, Nullable]
        public string Jmeno { get; set; }
        
        [Column, Nullable]
        public int? Velikost { get; set; }
        
        [Column, Nullable]
        public int GalaxieId { get; set; }
        
        [Column, Nullable]
        public Guid? Identifikator { get; set; }

        public virtual Galaxie Galaxie { get; set; }
    }
}