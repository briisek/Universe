using System.Collections.Generic;
using LinqToDB.Mapping;
using Nielsen.Admosphere.Fw2.DataAccess.Linq2db;
using Nielsen.Admosphere.Fw2.DataAccess.Linq2db.DaoFactory;
using Universe.Entities.Dao.Impl;

namespace Universe.Entities
{
    [DaoFactory(DaoType = typeof(GalaxieDao))]
    [Table("Galaxie")]
    public class Galaxie : DatabaseEntityIdentityIntKey<Galaxie>
    {
        [Column, Nullable]
        public string Jmeno { get; set; }

        [Column, Nullable]
        public long? PolohaX { get; set; }

        [Column, Nullable]
        public long? PolohaY { get; set; }

        [Column, Nullable]
        public long? PolohaZ { get; set; }

        public ICollection<Planetum> Planeta { get; set; } = new HashSet<Planetum>();
    }
}