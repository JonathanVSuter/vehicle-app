namespace VeiculosApp.Core.Common.Command
{
    public interface ICommandHandler<in T> where T : ICommand
    {
        void Handle(T command);        
    }
}
