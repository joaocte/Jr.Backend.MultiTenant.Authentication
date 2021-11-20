using Jr.Backend.Libs.Domain.Abstractions.Interfaces.Repository;
using Jr.Backend.MultiTenant.Authentication.Infrastructure.Entity;

namespace Jr.Backend.MultiTenant.Authentication.Infrastructure.Interfaces
{
    public interface ITenantRepository : IRepository<Tenant>
    {
    }
}