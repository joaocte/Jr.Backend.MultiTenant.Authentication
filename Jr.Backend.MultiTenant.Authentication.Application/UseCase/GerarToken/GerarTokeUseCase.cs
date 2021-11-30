using Jror.Backend.Libs.Security.Abstractions;
using Jror.Backend.MultiTenant.Authentication.Domain.Commands.Request;
using Jror.Backend.MultiTenant.Authentication.Domain.Commands.Response;
using Jror.Backend.MultiTenant.Authentication.Infrastructure.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Jror.Backend.MultiTenant.Authentication.Application.UseCase.GerarToken
{
    public class GerarTokeUseCase : IGerarTokenUseCase
    {
        private readonly ITenantRepository _tenantRepository;

        public GerarTokeUseCase(ITenantRepository tenantRepository)
        {
            this._tenantRepository = tenantRepository;
        }

        public async Task<GerarTokenCommandResponse> ExecuteAsync(GerarTokenCommand query, CancellationToken cancellationToken = default)
        {
            var tenant = await
                _tenantRepository.GetAsync(x => x.ClientId == query.ClientId && x.ClientSecret == query.ClientSecret, cancellationToken);

            var expires = DateTime.UtcNow.AddHours(2);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("ClientId", $"{tenant.ClientId}"),
                    new Claim("ClientSecret", $"{tenant.ClientSecret}"),
                    new Claim("TenantName", $"{tenant.TenantName}"),
                    new Claim("TenantKey", $"{tenant.TenantKey}"),
                }),
                Expires = expires,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Constants.BytesPrivateKey), SecurityAlgorithms.HmacSha512),
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new GerarTokenCommandResponse(tokenHandler.WriteToken(token), expires);
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