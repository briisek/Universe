using System;
using System.Collections.Generic;

#nullable disable

namespace Universe.DatabaseLayer.Model
{
    public partial class Galaxie
    {
        public Galaxie()
        {
            Planeta = new HashSet<Planetum>();
        }

        public int Id { get; set; }
        public string Jmeno { get; set; }
        public long? PolohaX { get; set; }
        public long? PolohaY { get; set; }
        public long? PolohaZ { get; set; }

        public virtual ICollection<Planetum> Planeta { get; set; }
    }
}
