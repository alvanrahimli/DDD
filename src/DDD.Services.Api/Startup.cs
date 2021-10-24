using DDD.Infra.CrossCutting.IoC;
using DDD.Services.Api.Configurations;
using DDD.Services.Api.StartupExtensions;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DDD.Services.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public IConfiguration Configuration { get; }
        private readonly IWebHostEnvironment _env;

        public void ConfigureServices(IServiceCollection services)
        {
            // ----- Database -----
            services.AddCustomizedDatabase(Configuration, _env);

            // ----- Auth -----
            services.AddCustomizedAuth(Configuration);

            // ----- AutoMapper -----
            services.AddAutoMapperSetup();

            // Adding MediatR for Domain Events and Notifications
            services.AddMediatR(typeof(Startup));

            services.AddCustomizedHash(Configuration);

            // ----- Swagger UI -----
            services.AddCustomizedSwagger(_env);

            // ----- Health check -----
            services.AddCustomizedHealthCheck(Configuration, _env);

            // .NET Native DI Abstraction
            RegisterServices(services);

            services.AddControllers()
                .AddJsonOptions(x => {
                    x.JsonSerializerOptions.IgnoreNullValues = true;
                    // x.JsonSerializerOptions.MaxDepth = 3;
                });
        }

        public void Configure(IApplicationBuilder app)
        {
            // ----- Error Handling -----
            app.UseCustomizedErrorHandling(_env);

            app.UseRouting();

            // ----- CORS -----
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            // ----- Auth -----
            app.UseCustomizedAuth();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                // ----- Health check -----
                HealthCheckExtension.UseCustomizedHealthCheck(endpoints, _env);
            });

            // ----- Swagger UI -----
            app.UseCustomizedSwagger(_env);
        }

        private static void RegisterServices(IServiceCollection services)
        {
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}
