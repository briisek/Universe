using System;
using System.Linq;
using System.Collections.Generic;

using System.Data.SqlClient;
using LinqToDB;
using LinqToDB.DataProvider.SqlServer;
using LinqToDB.Data;
using LinqToDB.Mapping;
using LinqToDB.SqlQuery;

namespace Universe.Entities
{
    public static class UniverseContext
    {
        private const string ConnectionString =
            "Server=sqltest02;Database=Vesmir;Trusted_Connection=True";

        #region Vlastnost
        
        public static ICollection<Vlastnost> GetAllVlastnosts()
        {
            using (var db = SqlServerTools.CreateDataConnection(ConnectionString))
            {
                var q =
                    from p in db.GetTable<Vlastnost>()
                    select p;
                
                return q.ToList();
            }
        }

        public static void UpdateVlastnost(int id, string nazev)
        {
            using (var db = SqlServerTools.CreateDataConnection(ConnectionString))
            {
                Vlastnost vlastnost = new Vlastnost();
                vlastnost.Id = id;
                vlastnost.Nazev = nazev;
                db.Update(vlastnost);

            }
        }

        public static void InsertVlastnost(string nazev)
        {
            using (var db = SqlServerTools.CreateDataConnection(ConnectionString))
            {
                int newId = GetAllVlastnosts().Max(x => x.Id) + 1;

                Vlastnost vlastnost = new Vlastnost();
                vlastnost.Id = newId;
                vlastnost.Nazev = nazev;
                
                db.Insert(vlastnost);
            }
        }

        public static void DeleteVlastnost(Vlastnost vlastnost)
        {
            using (var db = SqlServerTools.CreateDataConnection(ConnectionString))
            {
                db.Delete(vlastnost);
            }
        }
        
        #endregion
    }
}