using Jr.Backend.MultiTenant.Authentication.Domain.Commands.Request;
using Jr.Backend.MultiTenant.Authentication.Domain.Commands.Response;
using Jr.Backend.MultiTenant.Authentication.Infrastructure.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Jr.Backend.MultiTenant.Authentication.Application.UseCase.GerarToken
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
            var tenant = await _tenantRepository.GetAsync(
                x => x.ClientSecret == query.ClientSecret
                     && x.ClientId == query.ClientId, cancellationToken);

            var claims = new[]
            {
                new Claim("TenantName", tenant.TenantName),
                new Claim("ClientId", tenant.ClientId.ToString()),
                new Claim("ClientSecret", tenant.ClientSecret.ToString()),
                new Claim("TenantKey", tenant.TenantKey)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tenant.KeySecret));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddMinutes(1);

            JwtSecurityToken token = new JwtSecurityToken(
                claims: claims,
                expires: expiration,
                signingCredentials: creds);
            return new GerarTokenCommandResponse(new JwtSecurityTokenHandler().WriteToken(token), expiration);
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