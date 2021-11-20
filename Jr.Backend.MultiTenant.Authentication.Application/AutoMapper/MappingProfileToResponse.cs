using AutoMapper;
using Jr.Backend.MultiTenant.Authentication.Domain.Commands.Request;
using Jr.Backend.MultiTenant.Authentication.Domain.Commands.Response;
using Jr.Backend.MultiTenant.Authentication.Domain.Querys.Response;
using Jr.Backend.MultiTenant.Authentication.Infrastructure.Entity;

namespace Jr.Backend.MultiTenant.Authentication.Application.AutoMapper
{
    public class MappingProfileToResponse : Profile
    {
        public MappingProfileToResponse()
        {
            CreateMap<Tenant, CadastrarTenantCommand>();
            CreateMap<Tenant, CadastrarTenantCommandResponse>();
            CreateMap<Tenant, ConsultarTenantQueryResponse>();
        }
    }
}