using Jr.Backend.Libs.Domain.Abstractions;
using Jr.Backend.MultiTenant.Authentication.Domain.Validations;
using Jr.Backend.MultiTenant.Authentication.Domain.ValueObjects.Enum;
using System;
using System.Text.Json.Serialization;

namespace Jr.Backend.MultiTenant.Authentication.Domain
{
    public class Tenant : Entity
    {
        [JsonConstructor]
        public Tenant(string tenantName, string tenantKey)
        {
            ClientId = Guid.NewGuid();
            ClientSecret = Guid.NewGuid();
            Status = Status.Ativo;
            TenantName = tenantName;
            TenantKey = tenantKey;
            Id = Guid.NewGuid();

            Validate(this, new TenantValidation());
        }

        public Guid ClientId { get; private set; }
        public Guid ClientSecret { get; private set; }
        public Status Status { get; private set; }
        public string TenantName { get; private set; }
        public string TenantKey { get; private set; }
    }
}