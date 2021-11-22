using Jr.Backend.Libs.Domain.Abstractions.Exceptions;
using Jr.Backend.MultiTenant.Authentication.Domain.Commands.Request;
using Jr.Backend.MultiTenant.Authentication.Domain.Commands.Response;
using Jr.Backend.MultiTenant.Authentication.Domain.ValueObjects.Enum;
using Jr.Backend.MultiTenant.Authentication.Infrastructure.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Jr.Backend.MultiTenant.Authentication.Application.UseCase.GerarToken
{
    public class GerarTokenValidationUseCase : IGerarTokenUseCase
    {
        private readonly ITenantRepository _tenantRepository;
        private readonly IGerarTokenUseCase _gerarTokenUseCase;

        public GerarTokenValidationUseCase(ITenantRepository tenantRepository, IGerarTokenUseCase gerarTokenUseCase)
        {
            _tenantRepository = tenantRepository;
            this._gerarTokenUseCase = gerarTokenUseCase;
        }

        public async Task<GerarTokenCommandResponse> ExecuteAsync(GerarTokenCommand query, CancellationToken cancellationToken = default)
        {
            var tenantCadastrado = await _tenantRepository.ExistsAsync(x => x.ClientId == query.ClientId && x.ClientSecret == query.ClientSecret && x.Status == Status.Ativo.ToString(), cancellationToken);

            if (!tenantCadastrado)
                throw new NotFoundException("Não foi encontrado Tenant ativo para os dados informados");

            return await _gerarTokenUseCase.ExecuteAsync(query, cancellationToken);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _tenantRepository?.Dispose();
                _gerarTokenUseCase?.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}