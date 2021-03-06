using System.Threading;
using System.Threading.Tasks;
using Jr.Backend.MultiTenant.Authentication.Application.UseCase.GerarToken;
using Jr.Backend.MultiTenant.Authentication.Domain.Commands.Request;
using Jr.Backend.MultiTenant.Authentication.Domain.Commands.Response;
using MediatR;

namespace Jr.Backend.MultiTenant.Authentication.Application.Handlers
{
    public class GerarTokenHandler : IRequestHandler<GerarTokenCommand, GerarTokenCommandResponse>
    {
        private readonly IGerarTokenUseCase _gerarTokenUseCase;

        public GerarTokenHandler(IGerarTokenUseCase gerarTokenUseCase)
        {
            this._gerarTokenUseCase = gerarTokenUseCase;
        }

        public async Task<GerarTokenCommandResponse> Handle(GerarTokenCommand request, CancellationToken cancellationToken)
        {
            return await _gerarTokenUseCase.ExecuteAsync(request, cancellationToken);
        }
    }
}