using Jr.Backend.MultiTenant.Authentication.Domain.Querys.Request;
using Jr.Backend.MultiTenant.Authentication.Domain.Querys.Response;
using System;
using System.Threading.Tasks;

namespace Jr.Backend.MultiTenant.Authentication.Application.UseCase.ValidarToken
{
    public interface IValidarTokenUseCase : IDisposable
    {
        Task<ValidarTokenQueryResponse> ExecuteAsync(ValidarTokenQuery query);
    }
}