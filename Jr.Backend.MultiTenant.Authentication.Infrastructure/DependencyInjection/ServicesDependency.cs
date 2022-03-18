using Jr.Backend.MultiTenant.Authentication.Infrastructure.Entity;
using Jr.Backend.MultiTenant.Authentication.Infrastructure.Interfaces;
using Jr.Backend.MultiTenant.Authentication.Infrastructure.Repository.MongoDb;
using Jror.Backend.Libs.Infrastructure.MongoDB.Abstractions;
using Jror.Backend.Libs.Infrastructure.MongoDB.Abstractions.Interfaces;
using Jror.Backend.Libs.Infrastructure.MongoDB.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Jr.Backend.MultiTenant.Authentication.Infrastructure.DependencyInjection
{
    public static class ServicesDependency
    {
        public static void AddServiceDependencyInfrastructure(this IServiceCollection services)
        {
            services.AddServiceDependencyJrorInfrastructureMongoDb(ConnectionType.ReplicaSet);

            services.AddScoped<ITenantRepository>(p =>
            {
                var mongoContext = p.GetService<IMongoContext>();
                return new TenantRepository(mongoContext, nameof(Tenant));
            });
        }
    }
}