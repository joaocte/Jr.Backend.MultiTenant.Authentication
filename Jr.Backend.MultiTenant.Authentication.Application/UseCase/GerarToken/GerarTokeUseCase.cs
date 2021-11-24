using Jr.Backend.MultiTenant.Authentication.Domain.Commands.Request;
using Jr.Backend.MultiTenant.Authentication.Domain.Commands.Response;
using Jr.Backend.MultiTenant.Authentication.Infrastructure.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Jr.Backend.MultiTenant.Authentication.Application.UseCase.GerarToken
{
    public class GerarTokeUseCase : IGerarTokenUseCase
    {
        private readonly ITenantRepository _tenantRepository;

        public GerarTokeUseCase(ITenantRepository tenantRepository)
        {
            this._tenantRepository = tenantRepository;
        }

        public async Task<GerarTokenCommandResponse> ExecuteAsync(GerarTokenCommand query, CancellationToken cancellationToken = default)
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