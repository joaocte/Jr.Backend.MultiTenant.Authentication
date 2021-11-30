using Jror.Backend.MultiTenant.Authentication.Application.UseCase.CadastrarTenant;
using Jror.Backend.MultiTenant.Authentication.Domain.Commands.Request;
using Jror.Backend.MultiTenant.Authentication.Domain.Commands.Response;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Jror.Backend.MultiTenant.Authentication.Application.Handlers
{
    public class CadastrarTenantHandler : IRequestHandler<CadastrarTenantCommand, CadastrarTenantCommandResponse>
    {
        private readonly ICadastrarTenantUseCase _cadastrarTenantUseCase;

        public CadastrarTenantHandler(ICadastrarTenantUseCase cadastrarTenantUseCase)
        {
            this._cadastrarTenantUseCase = cadastrarTenantUseCase;
        }

        public async Task<CadastrarTenantCommandResponse> Handle(CadastrarTenantCommand request, CancellationToken cancellationToken)
        {
            return await _cadastrarTenantUseCase.ExecuteAsync(request, cancellationToken);
        }
    }
}