using Jr.Backend.MultiTenant.Authentication.Infrastructure.Entity;
using Jr.Backend.MultiTenant.Authentication.Infrastructure.Interfaces;
using Jror.Backend.Libs.Infrastructure.MongoDB.Abstractions.Interfaces;
using Jror.Backend.Libs.Infrastructure.MongoDB.Repository;

namespace Jr.Backend.MultiTenant.Authentication.Infrastructure.Repository.MongoDb
{
    public class TenantRepository : Repository<Tenant>, ITenantRepository
    {
        public TenantRepository(IMongoContext context, string collectionName) : base(context, collectionName)
        {
        }
    }
}