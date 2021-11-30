using AutoMapper;
using Jror.Backend.MultiTenant.Authentication.Domain.Commands.Request;
using Jror.Backend.MultiTenant.Authentication.Domain.Commands.Response;
using Jror.Backend.MultiTenant.Authentication.Domain.Querys.Response;
using Jror.Backend.MultiTenant.Authentication.Infrastructure.Entity;

namespace Jror.Backend.MultiTenant.Authentication.Application.AutoMapper
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