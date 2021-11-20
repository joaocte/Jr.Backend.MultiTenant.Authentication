using System;
using System.Text.Json.Serialization;

namespace Jr.Backend.MultiTenant.Authentication.Domain.Querys.Response
{
    public class ConsultarTenantQueryResponse
    {
        [JsonConstructor]
        public ConsultarTenantQueryResponse(Guid clientId, Guid clientSecret, string tenantName, string tenantKey)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
            TenantName = tenantName;
            TenantKey = tenantKey;
        }

        public Guid ClientId { get; private set; }
        public Guid ClientSecret { get; private set; }
        public string TenantName { get; private set; }

        public string TenantKey { get; private set; }
        public string Status { get; private set; }
    }
}