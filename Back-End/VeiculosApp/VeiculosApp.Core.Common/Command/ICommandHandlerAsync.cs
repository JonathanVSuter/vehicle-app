using System.Threading.Tasks;

namespace VeiculosApp.Core.Common.Command
{
    public interface ICommandHandlerAsync<in T> where T : ICommand
    {
        Task HandleAsync(T command);
    }
}
