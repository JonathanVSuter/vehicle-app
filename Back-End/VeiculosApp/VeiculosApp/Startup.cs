using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using VeiculosApp.Application;
using VeiculosApp.Application.CommandHandlers;
using VeiculosApp.Application.QueryHandlers;
using VeiculosApp.Infra.Repositories.EF;
using VeiculosApp.Profiles;

namespace VeiculosApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddRepositories(Configuration);
            services.AddExecutors();
            services.AddSwaggerGen();
            services.AddCommandHandlers();
            services.AddQueryHandlers();
            services.AddAutoMapper(Assembly.GetAssembly(typeof(VehicleProfile)));            
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Vehicles API");
                c.RoutePrefix = string.Empty;
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
