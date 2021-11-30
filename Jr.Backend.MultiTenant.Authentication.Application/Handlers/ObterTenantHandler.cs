using Jror.Backend.MultiTenant.Authentication.Application.UseCase.ObterTenant;
using Jror.Backend.MultiTenant.Authentication.Domain.Querys.Request;
using Jror.Backend.MultiTenant.Authentication.Domain.Querys.Response;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Jror.Backend.MultiTenant.Authentication.Application.Handlers
{
    public class ObterTenantHandler : IRequestHandler<ConsultarTenantQuery, ConsultarTenantQueryResponse>
    {
        private readonly IObterTenantUseCase _obterTenantUseCase;

        public ObterTenantHandler(IObterTenantUseCase obterTenantUseCase)
        {
            this._obterTenantUseCase = obterTenantUseCase;
        }

        public async Task<ConsultarTenantQueryResponse> Handle(ConsultarTenantQuery request, CancellationToken cancellationToken)
        {
            return await _obterTenantUseCase.ExecuteAsync(request, cancellationToken);
        }
    }
}