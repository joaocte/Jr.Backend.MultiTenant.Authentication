using Jr.Backend.Libs.Domain.Abstractions.Exceptions;
using Jr.Backend.Libs.Security.Abstractions;
using Jr.Backend.MultiTenant.Authentication.Domain.Querys.Request;
using Jr.Backend.MultiTenant.Authentication.Domain.Querys.Response;
using Jr.Backend.MultiTenant.Authentication.Infrastructure.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jr.Backend.MultiTenant.Authentication.Application.UseCase.ValidarToken
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
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(query.Token);
            var clientId = jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == "ClientId")?.Value;
            var clientSecret = jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == "ClientSecret")?.Value;
            var tenantName = jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == "TenantName")?.Value;
            var tenantKey = jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == "TenantKey")?.Value;

            var clientIdGuid = string.IsNullOrWhiteSpace(clientId) ? Guid.Empty : new Guid(clientId);
            var clientSecretGuid = string.IsNullOrWhiteSpace(clientSecret) ? Guid.Empty : new Guid(clientSecret);
            var tenant = await _tenantRepository.GetAsync(x =>
                x.ClientId == clientIdGuid && x.ClientSecret == clientSecretGuid);

            if (tenant == null)
                throw new NotFoundException("Token Iválido");

            var validationParameters = GetValidationParameters();
            SecurityToken validatedToken;
            var principal = handler.ValidateToken(query.Token, validationParameters, out validatedToken);
            return new ValidarTokenQueryResponse
            {
                IsValid = (tenantName == tenant.TenantName && tenantKey == tenant.TenantKey)
            };
        }

        private static TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters()
            {
                ValidateLifetime = false,
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidIssuer = null,
                ValidAudience = null,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Constants.PrivateKey)) // The same key as the one that generate the token
            };
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