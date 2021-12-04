using AutoMapper;
using Jr.Backend.MultiTenant.Authentication.Domain.Commands.Request;
using Jr.Backend.MultiTenant.Authentication.Domain.Commands.Response;
using Jr.Backend.MultiTenant.Authentication.Domain.Querys.Response;
using Jr.Backend.MultiTenant.Authentication.Infrastructure.Entity;

namespace Jr.Backend.MultiTenant.Authentication.Application.AutoMapper
{
    public class MappingProfileToEntity : Profile
    {
        public MappingProfileToEntity()
        {
            CreateMap<Domain.Tenant, Tenant>();
            CreateMap<CadastrarTenantCommand, Tenant>();
            CreateMap<CadastrarTenantCommandResponse, Tenant>();
            CreateMap<ConsultarTenantQueryResponse, Tenant>();
        }
    }
}