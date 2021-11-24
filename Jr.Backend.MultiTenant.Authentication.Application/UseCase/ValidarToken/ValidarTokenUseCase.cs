using Jr.Backend.MultiTenant.Authentication.Domain.Querys.Request;
using Jr.Backend.MultiTenant.Authentication.Domain.Querys.Response;
using Jr.Backend.MultiTenant.Authentication.Infrastructure.Interfaces;
using System;
using System.Threading.Tasks;

namespace Jr.Backend.MultiTenant.Authentication.Application.UseCase.ValidarToken
{
    public class ValidarTokenUseCase : IValidarTokenUseCase
    {
        private readonly ITenantRepository _tenantRepository;

        public ValidarTokenUseCase(ITenantRepository tenantRepository)
        {
            this._tenantRepository = tenantRepository;
        }

        public async Task<ValidarTokenQueryResponse> ExecuteAsync(ValidarTokenQuery query)
        {
            return default;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _tenantRepository?.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}