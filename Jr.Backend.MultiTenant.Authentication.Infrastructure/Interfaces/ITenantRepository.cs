using Jr.Backend.MultiTenant.Authentication.Infrastructure.Entity;
using Jror.Backend.Libs.Infrastructure.Data.Shared.Interfaces;

namespace Jr.Backend.MultiTenant.Authentication.Infrastructure.Interfaces
{
    public interface ITenantRepository : IRepository<Tenant>
    {
    }
}