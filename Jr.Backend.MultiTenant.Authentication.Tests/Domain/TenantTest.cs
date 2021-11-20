using Jr.Backend.MultiTenant.Authentication.Domain;
using System;
using Xunit;

namespace Jr.Backend.MultiTenant.Authentication.Tests.Domain
{
    public class TenantTest
    {
        [Fact]
        public void AoInstanciarUmTenantValido_RetornarTenant()
        {
            var tenant = new Tenant("tenantName", "tenantKey");

            Assert.True(tenant.Valid);
            Assert.IsType<Guid>(tenant.ClientSecret);
            Assert.IsType<Guid>(tenant.ClientId);
            Assert.Equal("tenantName", tenant.TenantName);
            Assert.Equal("tenantKey", tenant.TenantKey);
        }
    }
}