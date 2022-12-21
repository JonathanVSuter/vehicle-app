using System;
using System.Threading.Tasks;
using VeiculosApp.Core.Common.Command;

namespace VeiculosApp.Application
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;
        public CommandDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public void Dispatch<T>(T command) where T : ICommand
        {
            if (command == null) throw new ArgumentNullException(nameof(command), "Command cannot be null");

            var service = _serviceProvider.GetService(typeof(ICommandHandler<T>)) as ICommandHandler<T>;
            service.Handle(command);
        }
        public TResult Dispatch<T, TResult>(T command) where T : ICommand
        {
            if (command == null) throw new ArgumentNullException(nameof(command), "Command cannot be null");

            var service = _serviceProvider.GetService(typeof(ICommandHandlerWithResult<T, TResult>)) as ICommandHandlerWithResult<T, TResult>;
            return service.Handle(command);
        }
        public async Task<TResult> DispatchAsync<T, TResult>(T command) where T : ICommand
        {
            if (command == null) throw new ArgumentNullException(nameof(command), "Command cannot be null");

            var service = _serviceProvider.GetService(typeof(ICommandHandlerWithResult<T, Task<TResult>>)) as ICommandHandlerWithResult<T, Task<TResult>>;
            return  await service.Handle(command).ConfigureAwait(true);
        }

        public async Task DispatchAsync<T>(T command) where T : ICommand
        {
            if (command == null) throw new ArgumentNullException(nameof(command), "Command cannot be null");

            var service = _serviceProvider.GetService(typeof(ICommandHandlerAsync<T>)) as ICommandHandlerAsync<T>;
            await service.HandleAsync(command).ConfigureAwait(true);
        }
    }
}
