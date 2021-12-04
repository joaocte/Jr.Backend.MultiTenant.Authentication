using System;
using System.Threading;
using System.Threading.Tasks;
using Jr.Backend.MultiTenant.Authentication.Domain.Querys.Request;
using Jr.Backend.MultiTenant.Authentication.Domain.Querys.Response;

namespace Jr.Backend.MultiTenant.Authentication.Application.UseCase.ObterTenant
{
    public interface IObterTenantUseCase : IDisposable
    {
        Task<ConsultarTenantQueryResponse> ExecuteAsync(ConsultarTenantQuery query, CancellationToken cancellationToken = default);
    }
}