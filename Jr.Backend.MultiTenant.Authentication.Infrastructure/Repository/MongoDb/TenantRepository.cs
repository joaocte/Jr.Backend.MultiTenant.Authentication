using Jror.Backend.Libs.Infrastructure.MongoDB.Abstractions.Interfaces;
using Jror.Backend.Libs.Infrastructure.MongoDB.Repository;
using Jror.Backend.MultiTenant.Authentication.Infrastructure.Entity;
using Jror.Backend.MultiTenant.Authentication.Infrastructure.Interfaces;

namespace Jror.Backend.MultiTenant.Authentication.Infrastructure.Repository.MongoDb
{
    public class TenantRepository : MongoRepository<Tenant>, ITenantRepository
    {
        public TenantRepository(IMongoContext context, string collectionName) : base(context, collectionName)
        {
        }
    }
}