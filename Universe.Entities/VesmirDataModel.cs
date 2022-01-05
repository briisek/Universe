using System;
using System.Data;
using LinqToDB;
using LinqToDB.DataProvider;
using LinqToDB.Mapping;
using Nielsen.Admosphere.Fw2.DataAccess.Linq2db;

namespace Universe.Entities
{
    public class VesmirDataModel : TransactionDbManager
    {
        public VesmirDataModel()
        {
        }

        public VesmirDataModel(MappingSchema mappingSchema) : base(mappingSchema)
        {
        }

        public VesmirDataModel(string configurationString, MappingSchema mappingSchema) : base(configurationString, mappingSchema)
        {
        }

        public VesmirDataModel(string configurationString) : base(configurationString)
        {
        }

        public VesmirDataModel(string providerName, string connectionString, MappingSchema mappingSchema) : base(providerName, connectionString, mappingSchema)
        {
        }

        public VesmirDataModel(string providerName, string connectionString) : base(providerName, connectionString)
        {
        }

        public VesmirDataModel(IDataProvider dataProvider, string connectionString, MappingSchema mappingSchema) : base(dataProvider, connectionString, mappingSchema)
        {
        }

        public VesmirDataModel(IDataProvider dataProvider, string connectionString) : base(dataProvider, connectionString)
        {
        }

        public VesmirDataModel(IDataProvider dataProvider, Func<IDbConnection> connectionFactory, MappingSchema mappingSchema) : base(dataProvider, connectionFactory, mappingSchema)
        {
        }

        public VesmirDataModel(IDataProvider dataProvider, Func<IDbConnection> connectionFactory) : base(dataProvider, connectionFactory)
        {
        }

        public VesmirDataModel(IDataProvider dataProvider, IDbConnection connection, MappingSchema mappingSchema) : base(dataProvider, connection, mappingSchema)
        {
        }

        public VesmirDataModel(IDataProvider dataProvider, IDbConnection connection) : base(dataProvider, connection)
        {
        }

        public VesmirDataModel(IDataProvider dataProvider, IDbConnection connection, bool disposeConnection) : base(dataProvider, connection, disposeConnection)
        {
        }

        public VesmirDataModel(IDataProvider dataProvider, IDbTransaction transaction, MappingSchema mappingSchema) : base(dataProvider, transaction, mappingSchema)
        {
        }

        public VesmirDataModel(IDataProvider dataProvider, IDbTransaction transaction) : base(dataProvider, transaction)
        {
        }


        public ITable<Galaxie> Galaxies => GetTable<Galaxie>();
    }
}