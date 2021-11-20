using Jr.Backend.MultiTenant.Authentication.Domain.Querys.Response;
using MediatR;
using System;

namespace Jr.Backend.MultiTenant.Authentication.Domain.Querys.Request
{
    public class ConsultarTenantQuery : IRequest<ConsultarTenantQueryResponse>
    {
        public Guid ClientId { get; set; }

        public Guid ClientSecret { get; set; }
    }
}