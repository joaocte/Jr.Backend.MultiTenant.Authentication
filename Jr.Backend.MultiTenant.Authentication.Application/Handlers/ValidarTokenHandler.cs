using Jror.Backend.MultiTenant.Authentication.Application.UseCase.ValidarToken;
using Jror.Backend.MultiTenant.Authentication.Domain.Querys.Request;
using Jror.Backend.MultiTenant.Authentication.Domain.Querys.Response;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Jror.Backend.MultiTenant.Authentication.Application.Handlers
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