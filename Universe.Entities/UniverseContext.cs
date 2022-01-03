using System;
using System.Linq;

using LinqToDB.DataProvider.SqlServer;
using LinqToDB.Data;
using LinqToDB.Mapping;

namespace Universe.Entities
{
    public class UniverseContext
    {
        private const string ConnectionString =
            "Server=sqltest02;Database=Vesmir;Trusted_Connection=True";

        public void ListPlanetProperties()
        {
            using (var db = SqlServerTools.CreateDataConnection(ConnectionString))
            {
                var q =
                    from p in db.GetTable<Vlastnost>()
                    select p;

                foreach (var property in q)
                {
                   Console.WriteLine("ID: {0}, Name: {1}",
                       property.Id,
                       property.Nazev); 
                }
            }
        }
    }
}