using Jr.Backend.MultiTenant.Authentication.Domain.Commands.Request;
using Jr.Backend.MultiTenant.Authentication.Domain.Commands.Response;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Jr.Backend.MultiTenant.Authentication.Application.UseCase.GerarToken
{
    public interface IGerarTokenUseCase : IDisposable
    {
        Task<GerarTokenCommandResponse> ExecuteAsync(GerarTokenCommand query, CancellationToken cancellationToken = default);
    }
}