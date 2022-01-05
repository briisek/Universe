using System.Collections.Generic;
using System.Data;
using System.Linq;
using LinqToDB;
using Nielsen.Admosphere.Fw2.DataAccess.Linq2db.Dao;

namespace Universe.Entities.Dao.Impl
{
    public class GalaxieDao : EntityIdentityKeyDaoBase<Galaxie, VesmirDataModel, int>, IGalaxieDao
    {
        public GalaxieDao(string connectionString, IsolationLevel isolationLevel) 
            : base(connectionString, isolationLevel)
        {
        }

        public GalaxieDao(string connectionString) : base(connectionString)
        {
        }

        public IList<Galaxie> SelectByName(string name)
        {
            using (var model = CreateDbContext())
            {
                return model.Galaxies.Where(x => x.Jmeno.Contains(name)).ToArray();
            }
        }
        
        public void InsertGalaxie(string nazev)
        {
            Galaxie galaxie = new Galaxie();
            
            using (var model = CreateDbContext())
            {
                model.Insert(galaxie);
            }
        }


        public void DeleteGalaxie(string nazev)
        {
            using (var model = CreateDbContext())
            {
                model.Galaxies.Where(x => x.Jmeno == nazev).Delete();
            }
        }

    }
}