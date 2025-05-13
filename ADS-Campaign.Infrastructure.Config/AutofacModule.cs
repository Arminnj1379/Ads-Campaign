using System.Data;
using ADS_Campaign.Application.Services;
using ADS_Campaign.Domain;
using ADS_Campaign.Infrastructure.Persistance.Sql;
using ADS_Campaign.Infrastructure.Persistance.Sql.Repositories;
using Autofac;
using Microsoft.Data.SqlClient;

namespace ADS_Campaign.Infrastructure.Config
{
    public class AutofacModule : Module
    {
        private readonly string _connectionString;
        public AutofacModule(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(UserRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .WithParameter("connectionString", _connectionString)
                .AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(UserService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.Register(c => new SqlConnection(_connectionString))
                   .As<IDbConnection>()
                   .InstancePerLifetimeScope();
        }
    }
}
