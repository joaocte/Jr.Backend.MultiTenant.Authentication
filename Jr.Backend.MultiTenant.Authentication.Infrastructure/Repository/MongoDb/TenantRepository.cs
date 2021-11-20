using Jr.Backend.Libs.Infrastructure.MongoDB.Abstractions.Interfaces;
using Jr.Backend.Libs.Infrastructure.MongoDB.Repository;
using Jr.Backend.MultiTenant.Authentication.Infrastructure.Entity;
using Jr.Backend.MultiTenant.Authentication.Infrastructure.Interfaces;

namespace Jr.Backend.MultiTenant.Authentication.Infrastructure.Repository.MongoDb
{
    public class TenantRepository : MongoRepository<Tenant>, ITenantRepository
    {
        public TenantRepository(IMongoContext context, string collectionName) : base(context, collectionName)
        {
        }
    }
}