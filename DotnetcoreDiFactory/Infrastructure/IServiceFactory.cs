namespace DotnetcoreDiFactory.Infrastructure
{
    public interface IServiceFactory<T> where T : class
    {
        T Build();
    }
}
