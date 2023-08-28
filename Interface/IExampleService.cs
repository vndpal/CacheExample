namespace CacheExample.Interface
{
    public interface IExampleService
    {
        Task<string> GetValueFromCache(string key);
    }
}
