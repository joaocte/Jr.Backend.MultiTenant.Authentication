using Jror.Backend.Libs.Security.Abstractions;
using Jror.Backend.MultiTenant.Authentication.Domain.Querys.Request;
using Jror.Backend.MultiTenant.Authentication.Domain.Querys.Response;
using Jror.Backend.MultiTenant.Authentication.Infrastructure.Interfaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Jror.Backend.MultiTenant.Authentication.Application.UseCase.ValidarToken
{
    public class ValidarTokenUseCase : IValidarTokenUseCase
    {
        private readonly ITenantRepository _tenantRepository;

        public ValidarTokenUseCase(ITenantRepository tenantRepository)
        {
            this._tenantRepository = tenantRepository;
        }

        public async Task<ValidarTokenQueryResponse> ExecuteAsync(ValidarTokenQuery query)
        {
            var validToken = query.Token.Replace("bearer", "").TrimStart();
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(validToken);
            var clientId = jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == "ClientId")?.Value;
            var clientSecret = jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == "ClientSecret")?.Value;
            var tenantName = jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == "TenantName")?.Value;
            var tenantKey = jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == "TenantKey")?.Value;

            var clientIdGuid = string.IsNullOrWhiteSpace(clientId) ? Guid.Empty : new Guid(clientId);
            var clientSecretGuid = string.IsNullOrWhiteSpace(clientSecret) ? Guid.Empty : new Guid(clientSecret);

            var tenant = await _tenantRepository.GetAsync(x =>
                x.ClientId == clientIdGuid && x.ClientSecret == clientSecretGuid);

            if (tenant == null)
                throw new UnauthorizedAccessException("Token Informado é Iválido");

            var validationParameters = Constants.TokenValidationParameters;
            var principal = handler.ValidateToken(validToken, validationParameters, out _);

            return new ValidarTokenQueryResponse(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _tenantRepository?.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}