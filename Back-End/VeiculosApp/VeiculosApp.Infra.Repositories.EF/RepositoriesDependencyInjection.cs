using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VeiculosApp.Core.Domain.Models;
using VeiculosApp.Core.Domain.Repositories;

namespace VeiculosApp.Infra.Repositories.EF
{
    public static class RepositoriesDependencyInjection
    {
        public static void AddRepositories(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<AppVehiclesDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("VehiclesDb")));
            serviceCollection.AddIdentityCore<User>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<AppVehiclesDbContext>();
            serviceCollection.AddScoped<IVehicleRepository, VehicleRepository>();
            serviceCollection.AddScoped<IAdvertisementRepository, AdvertisementRepository>();
            serviceCollection.AddScoped<IAdvertisementImageRepository, AdvertisementImageRepository>();
            serviceCollection.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
