using Jror.Backend.MultiTenant.Authentication.Domain.Commands.Request;
using Jror.Backend.MultiTenant.Authentication.Domain.Commands.Response;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Jror.Backend.MultiTenant.Authentication.Application.UseCase.CadastrarTenant
{
    public interface ICadastrarTenantUseCase : IDisposable
    {
        Task<CadastrarTenantCommandResponse> ExecuteAsync(CadastrarTenantCommand command, CancellationToken cancellationToken = default);
    }
}