using Jr.Backend.MultiTenant.Authentication.Domain.Commands.Response;
using MediatR;

namespace Jr.Backend.MultiTenant.Authentication.Domain.Commands.Request
{
    public class CadastrarTenantCommand : IRequest<CadastrarTenantCommandResponse>
    {
        public CadastrarTenantCommand(string tenantName, string tenantKey)
        {
            TenantName = tenantName;
            TenantKey = tenantKey;
        }

        /// <summary>
        /// Nome do cliente
        /// </summary>
        public string TenantName { get; private set; }

        /// <summary>
        /// Chave unica que representa o cliente
        /// </summary>
        public string TenantKey { get; private set; }
    }
}