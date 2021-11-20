using Jr.Backend.Libs.Domain.Abstractions;
using Jr.Backend.MultiTenant.Authentication.Domain.Validations;
using Jr.Backend.MultiTenant.Authentication.Domain.ValueObjects.Enum;
using System;
using System.Linq;
using System.Text.Json.Serialization;

namespace Jr.Backend.MultiTenant.Authentication.Domain
{
    public class Tenant : Entity
    {
        private const string Chars = @"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%&*-/+.,_=";

        [JsonConstructor]
        public Tenant(string tenantName, string tenantKey)
        {
            ClientId = Guid.NewGuid();
            ClientSecret = Guid.NewGuid();
            Status = Status.Ativo;
            TenantName = tenantName;
            TenantKey = tenantKey;
            Id = Guid.NewGuid();
            KeySecret = GenerateRandomKeySecret();

            Validate(this, new TenantValidation());
        }

        public Guid ClientId { get; private set; }
        public Guid ClientSecret { get; private set; }
        public Status Status { get; private set; }
        public string TenantName { get; private set; }

        public string KeySecret { get; private set; }
        public string TenantKey { get; private set; }

        private string GenerateRandomKeySecret(int length = 64)
        {
            var random = new Random();
            var randomString = new string(Enumerable.Repeat(Chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            return randomString;
        }
    }
}