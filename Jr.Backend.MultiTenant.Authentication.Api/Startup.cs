using Jr.Backend.Libs.Framework.DependencyInjection;
using Jr.Backend.Libs.Security.DependencyInjection;
using Jr.Backend.MultiTenant.Authentication.Api.Swagger;
using Jr.Backend.MultiTenant.Authentication.Application.DependencyInjection;
using Jr.Backend.MultiTenant.Authentication.Infrastructure.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Jr.Backend.MultiTenant.Authentication.Api
{
    public class Startup
    {
        /// <inheritdoc/>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <inheritdoc/>
        public IConfiguration Configuration { get; }

        /// <inheritdoc/>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddApiVersioning(o =>
            {
                o.UseApiBehavior = false;
                o.ReportApiVersions = true;
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);

                o.ApiVersionReader = ApiVersionReader.Combine(
                    new HeaderApiVersionReader("x-api-version"),
                    new UrlSegmentApiVersionReader());
            });
            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
            services.ConfigureOptions<ConfigureSwaggerOptions>();

            services.AddSwaggerGen();
            services.AddServiceDependencyApplication();
            services.AddServiceDependencyInfrastructure();
            services.AddServiceDependencyJrFramework();
            services.AddServiceDependencyJrSecurityApi();
        }

        /// <inheritdoc/>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Jr.Backend.MultiTenant.Authentication.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}