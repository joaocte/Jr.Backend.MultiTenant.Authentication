using AutoMapper;
using Jr.Backend.MultiTenant.Authentication.Application.AutoMapper;
using Jr.Backend.MultiTenant.Authentication.Application.UseCase.CadastrarTenant;
using Jr.Backend.MultiTenant.Authentication.Application.UseCase.GerarToken;
using Jr.Backend.MultiTenant.Authentication.Application.UseCase.ObterTenant;
using Jr.Backend.MultiTenant.Authentication.Application.UseCase.ValidarToken;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Jr.Backend.MultiTenant.Authentication.Application.DependencyInjection
{
    public static class ServicesDependency
    {
        public static void AddServiceDependencyApplication(this IServiceCollection services)
        {
            services.AddScoped<ICadastrarTenantUseCase, CadastrarTenantUseCase>();
            services.Decorate<ICadastrarTenantUseCase, CadastrarTenantValidationUseCase>();

            services.AddScoped<IObterTenantUseCase, ObterTenantUseCase>();

            services.AddScoped<IGerarTokenUseCase, GerarTokeUseCase>();
            services.Decorate<IGerarTokenUseCase, GerarTokenValidationUseCase>();

            services.AddScoped<IValidarTokenUseCase, ValidarTokenUseCase>();

            services.AddMediatR(Assembly.GetExecutingAssembly());

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfileToDomain());
                mc.AddProfile(new MappingProfileToEntity());
                mc.AddProfile(new MappingProfileToResponse());
            });

            IMapper mapper = mapperConfig.CreateMapper();

            services.AddSingleton(mapper);
        }
    }
}