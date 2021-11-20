using Jr.Backend.MultiTenant.Authentication.Application.UseCase.ValidarToken;
using Jr.Backend.MultiTenant.Authentication.Domain.Querys.Request;
using Jr.Backend.MultiTenant.Authentication.Domain.Querys.Response;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Jr.Backend.MultiTenant.Authentication.Application.Handlers
{
    public class ValidarTokenHandler : IRequestHandler<ValidarTokenQuery, ValidarTokenQueryResponse>
    {
        private readonly IValidarTokenUseCase _validarTokenUseCase;

        public ValidarTokenHandler(IValidarTokenUseCase validarTokenUseCase)
        {
            this._validarTokenUseCase = validarTokenUseCase;
        }

        public async Task<ValidarTokenQueryResponse> Handle(ValidarTokenQuery request, CancellationToken cancellationToken)
        {
            return await _validarTokenUseCase.ExecuteAsync(request);
        }
    }
}