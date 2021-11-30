using Jror.Backend.MultiTenant.Authentication.Domain.Querys.Request;
using Jror.Backend.MultiTenant.Authentication.Domain.Querys.Response;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Jror.Backend.MultiTenant.Authentication.Application.UseCase.ObterTenant
{
    public interface IObterTenantUseCase : IDisposable
    {
        Task<ConsultarTenantQueryResponse> ExecuteAsync(ConsultarTenantQuery query, CancellationToken cancellationToken = default);
    }
}