namespace VeiculosApp.Core.Common.Query
{
    public interface IQueryHandler<in T, out TResult> where T : IQuery<TResult>
    {
        TResult Execute(T query);
    }
}
