using AutoMapper;
using Jror.Backend.MultiTenant.Authentication.Domain;
using Jror.Backend.MultiTenant.Authentication.Domain.Commands.Request;
using Jror.Backend.MultiTenant.Authentication.Domain.Commands.Response;
using Jror.Backend.MultiTenant.Authentication.Domain.Querys.Response;

namespace Jror.Backend.MultiTenant.Authentication.Application.AutoMapper
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