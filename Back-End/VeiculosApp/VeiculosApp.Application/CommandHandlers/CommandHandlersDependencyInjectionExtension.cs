using Microsoft.Extensions.DependencyInjection;
using VeiculosApp.Core.Common.Command;
using VeiculosApp.Core.Domain.Commands;
using VeiculosApp.Core.Domain.Models;

namespace VeiculosApp.Application.CommandHandlers
{
    public static class CommandHandlersDependencyInjectionExtension
    {
        public static void AddCommandHandlers(this IServiceCollection services)
        {
            services.AddScoped<ICommandHandlerWithResult<SaveVehicleCommand, Vehicle>, SaveVehicleCommandHandler>();
            services.AddScoped<ICommandHandler<SaveAdvertisementImageCommand>, SaveAdvertisementImageCommandHandler>();
            services.AddScoped<ICommandHandler<RemoveVehicleCommand>, RemoveVehicleCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateVehicleCommand>, UpdateVehicleCommandHandler>();
            services.AddScoped<ICommandHandler<RemoveAdvertisementImageCommand>, RemoveAdvertisementImageCommandHandler>();            
            services.AddScoped<ICommandHandler<RemoveUserCommand>, RemoveUserCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateUserCommand>, UpdateUserCommandHandler>();
            services.AddScoped<ICommandHandlerAsync<SaveUserCommand>, SaveUserCommandHandler>();            
            services.AddScoped<ICommandHandler<RemoveAdvertisementCommand>, RemoveAdvertisementCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateAdvertisementCommand>, UpdateAdvertisementCommandHandler>();
            services.AddScoped<ICommandHandler<SaveAdvertisementCommand>, SaveAdvertisementCommandHandler>();
        }
    }
}
