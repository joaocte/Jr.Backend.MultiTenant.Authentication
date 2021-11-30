using AutoMapper;
using Jror.Backend.MultiTenant.Authentication.Domain.Commands.Request;
using Jror.Backend.MultiTenant.Authentication.Domain.Commands.Response;
using Jror.Backend.MultiTenant.Authentication.Domain.Querys.Response;
using Jror.Backend.MultiTenant.Authentication.Infrastructure.Entity;

namespace Jror.Backend.MultiTenant.Authentication.Application.AutoMapper
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