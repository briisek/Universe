using System.Collections.Generic;
using Nielsen.Admosphere.Fw2.DataAccess.Linq2db.Dao;

namespace Universe.Entities.Dao
{
    public interface IGalaxieDao : IEntityDaoBase<Galaxie, int>
    {
        IList<Galaxie> SelectByName(string name);
        void InsertGalaxie(string nazev);
        void DeleteGalaxie(string nazev);
    }
}