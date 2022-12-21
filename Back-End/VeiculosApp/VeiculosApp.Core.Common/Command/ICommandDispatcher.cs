using System.Threading.Tasks;

namespace VeiculosApp.Core.Common.Command
{
    public interface ICommandDispatcher
    {
        void Dispatch<T>(T command) where T : ICommand;
        Task DispatchAsync<T>(T command) where T : ICommand;
        TResult Dispatch<T, TResult>(T command) where T : ICommand;
        Task<TResult> DispatchAsync<T, TResult>(T command) where T : ICommand;
    }
}
