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
            services.AddScoped<ICommandHandler<SaveAnnouncementImageCommand>, SaveAnnoucementImageCommandHandler>();
            services.AddScoped<ICommandHandler<RemoveVehicleCommand>, RemoveVehicleCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateVehicleCommand>, UpdateVehicleCommandHandler>();
            services.AddScoped<ICommandHandler<RemoveAnnouncementImageCommand>, RemoveAnnouncementImageCommandHandler>();            
            services.AddScoped<ICommandHandler<RemoveUserCommand>, RemoveUserCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateUserCommand>, UpdateUserCommandHandler>();
            services.AddScoped<ICommandHandler<SaveUserCommand>, SaveUserCommandHandler>();            
            services.AddScoped<ICommandHandler<RemoveAnnouncementCommand>, RemoveAnnouncementCommandHandler>();
        }
    }
}
