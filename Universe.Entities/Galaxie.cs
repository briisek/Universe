using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using LinqToDB.DataProvider.SqlServer;
using LinqToDB.Mapping;

namespace Universe.Entities
{
    [Table("Galaxie")]
    public class Galaxie
    {
        public Galaxie()
        {
            Planeta = new HashSet<Planetum>();
        }
        
        [PrimaryKey]
        public int Id { get; set; }

        [Column, Nullable]
        public string Jmeno { get; set; }

        [Column, Nullable]
        public long? PolohaX { get; set; }

        [Column, Nullable]
        public long? PolohaY { get; set; }

        [Column, Nullable]
        public long? PolohaZ { get; set; }

        public ICollection<Planetum> Planeta { get; set; } = new ObservableCollection<Planetum>();
    }
}