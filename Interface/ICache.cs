namespace CacheExample.Interface
{
    public interface ICache
    {
        T Get<T>(string key);
        void Set<T>(string key, T value, TimeSpan expirationTime);
        void Remove(string key);
    }

}
