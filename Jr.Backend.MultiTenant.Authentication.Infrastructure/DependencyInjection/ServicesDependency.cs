using Jr.Backend.Libs.Infrastructure.MongoDB.Abstractions;
using Jr.Backend.Libs.Infrastructure.MongoDB.Abstractions.Interfaces;
using Jr.Backend.Libs.Infrastructure.MongoDB.DependencyInjection;
using Jr.Backend.MultiTenant.Authentication.Infrastructure.Entity;
using Jr.Backend.MultiTenant.Authentication.Infrastructure.Interfaces;
using Jr.Backend.MultiTenant.Authentication.Infrastructure.Repository.MongoDb;
using Microsoft.Extensions.DependencyInjection;

namespace Jr.Backend.MultiTenant.Authentication.Infrastructure.DependencyInjection
{
    public static class ServicesDependency
    {
        public static void AddServiceDependencyInfrastructure(this IServiceCollection services)
        {
            services.AddServiceDependencyJrInfrastructureMongoDb(ConnectionType.DirectConnection);

            services.AddScoped<ITenantRepository>(p =>
            {
                var mongoContext = p.GetService<IMongoContext>();
                return new TenantRepository(mongoContext, nameof(Tenant));
            });
        }
    }
}