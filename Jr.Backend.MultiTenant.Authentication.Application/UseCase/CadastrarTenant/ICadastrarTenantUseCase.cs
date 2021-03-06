using System;
using System.Threading;
using System.Threading.Tasks;
using Jr.Backend.MultiTenant.Authentication.Domain.Commands.Request;
using Jr.Backend.MultiTenant.Authentication.Domain.Commands.Response;

namespace Jr.Backend.MultiTenant.Authentication.Application.UseCase.CadastrarTenant
{
    public interface ICadastrarTenantUseCase : IDisposable
    {
        Task<CadastrarTenantCommandResponse> ExecuteAsync(CadastrarTenantCommand command, CancellationToken cancellationToken = default);
    }
}