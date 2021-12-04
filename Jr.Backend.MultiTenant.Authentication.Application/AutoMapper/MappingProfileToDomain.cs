using AutoMapper;
using Jr.Backend.MultiTenant.Authentication.Domain;
using Jr.Backend.MultiTenant.Authentication.Domain.Commands.Request;
using Jr.Backend.MultiTenant.Authentication.Domain.Commands.Response;
using Jr.Backend.MultiTenant.Authentication.Domain.Querys.Response;

namespace Jr.Backend.MultiTenant.Authentication.Application.AutoMapper
{
    public class MappingProfileToDomain : Profile
    {
        public MappingProfileToDomain()
        {
            CreateMap<Infrastructure.Entity.Tenant, Tenant>();
            CreateMap<CadastrarTenantCommand, Tenant>();
            CreateMap<CadastrarTenantCommandResponse, Tenant>();
            CreateMap<ConsultarTenantQueryResponse, Tenant>();
        }
    }
}