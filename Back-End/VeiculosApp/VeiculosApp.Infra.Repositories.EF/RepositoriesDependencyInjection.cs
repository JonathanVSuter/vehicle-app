using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VeiculosApp.Core.Domain.Repositories;

namespace VeiculosApp.Infra.Repositories.EF
{
    public static class RepositoriesDependencyInjection
    {
        public static void AddRepositories(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<AppVehiclesDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("VehiclesDb")));
            serviceCollection.AddScoped<IVehicleRepository, VehicleRepository>();
            serviceCollection.AddScoped<IAnnouncementRepository, AnnouncementRepository>();
            serviceCollection.AddScoped<IAnnouncementImageRepository, AnnoucementImageRepository>();
        }
    }
}
