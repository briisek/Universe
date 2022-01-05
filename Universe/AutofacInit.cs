using System.Reflection;
using Autofac;
using Nielsen.Admosphere.Fw2.DataAccess.Linq2db.Autofac;
using Nielsen.Admosphere.Fw2.DataAccess.Linq2db.Dao;
using Universe.Entities;

namespace Universe;

public class AutofacInit
{
    public static ILifetimeScope Scope { get; private set; }

    public void Init()
    {
        var builder = new ContainerBuilder();

        builder.RegisterType<EntitiesSource>().As<IEntitiesSource>().SingleInstance();
        
        DependencyDaoModule dependencyDaoModule = new DependencyDaoModule(new[] { Assembly.GetAssembly(typeof(Galaxie)) },
            new DaoSourceConnectionStringSettings("vesmir", UniverseContext.ConnectionString));

        builder.RegisterModule(dependencyDaoModule);
        
        Scope = builder.Build();
    }
}