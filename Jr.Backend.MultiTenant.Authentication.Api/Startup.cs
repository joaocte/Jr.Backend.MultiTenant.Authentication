using Jror.Backend.Libs.Api.DependencyInjection;
using Jror.Backend.Libs.API.Abstractions;
using Jror.Backend.Libs.Framework.DependencyInjection;
using Jror.Backend.Libs.Security.DependencyInjection;
using Jror.Backend.MultiTenant.Authentication.Application.DependencyInjection;
using Jror.Backend.MultiTenant.Authentication.Infrastructure.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Jror.Backend.MultiTenant.Authentication.Api
{
    public class Startup
    {
        private readonly JrorApiOption jrApiOption;

        /// <inheritdoc/>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            jrApiOption = new JrorApiOption
            {
                Title = "Jror.Backend.MultiTenant.Authentication.Api",
                Description = "Api de Cadastro de Tenants e Autenticação",
                Email = "joaocte@gmail.com",
                Uri = "https://github.com/joaocte/Jror.Backend.MultiTenant.Authentication",
            };
        }

        /// <inheritdoc/>
        public IConfiguration Configuration { get; }

        /// <inheritdoc/>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddServiceDependencyJrorSecurityApi();
            services.AddServiceDependencyJrorApiSwagger(Configuration, () => jrApiOption);
            services.AddServiceDependencyApplication();
            services.AddServiceDependencyInfrastructure();
            services.AddServiceDependencyJrorFramework();
        }

        /// <inheritdoc/>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseJrorApiSwaggerSecurity(env, () => jrApiOption);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}