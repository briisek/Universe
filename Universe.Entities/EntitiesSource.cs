using System.Collections.Generic;
using System.Linq;
using Nielsen.Admosphere.Fw2.DataAccess.Linq2db;
using Nielsen.Admosphere.Fw2.DataAccess.Linq2db.DaoFactory;
using Nielsen.Admosphere.Fw2.DataAccess.Linq2db.Transactions;
using Universe.Entities.Dao;

namespace Universe.Entities
{
    public interface IEntitiesSource
    {
        IList<Galaxie> GetAllGalaxies();
        IList<Vlastnost> GetAllVlastnosts();
        void InsertNewGalaxie(string nazev);
    }

    public class EntitiesSource : IEntitiesSource
    {
        private readonly IGalaxieDao m_galaxieDao;

        public EntitiesSource(IGalaxieDao galaxieDao)
        {
            m_galaxieDao = galaxieDao;
        }


        public IList<Galaxie> GetAllGalaxies()
        {
            var galaxies = m_galaxieDao.SelectAll();

            return galaxies;
        }
        
        public IList<Vlastnost> GetAllVlastnosts()
        {
            return UniverseContext.GetAllVlastnosts().ToArray();
        }

        public void InsertNewGalaxie(string nazev)
        {
            void Action()
            {
                m_galaxieDao.DeleteGalaxie(nazev);
                m_galaxieDao.InsertGalaxie(nazev);
            }

            m_galaxieDao.CallInsideTransaction(Action);
        }
        
    }
}