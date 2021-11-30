using Jror.Backend.Libs.Infrastructure.Data.Shared.Interfaces;
using Jror.Backend.MultiTenant.Authentication.Infrastructure.Entity;

namespace Jror.Backend.MultiTenant.Authentication.Infrastructure.Interfaces
{
    public interface ITenantRepository : IRepository<Tenant>
    {
    }
}