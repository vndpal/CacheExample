using CacheExample.Interface;
using Microsoft.Extensions.Caching.Memory;

namespace CacheExample.Adaptor
{
    public class MemoryCacheAdapter : ICache
    {
        private readonly MemoryCache _cache;

        public MemoryCacheAdapter()
        {
            _cache = new MemoryCache(new MemoryCacheOptions());
        }

        public T Get<T>(string key)
        {
            return _cache.Get<T>(key);
        }

        public void Set<T>(string key, T value, TimeSpan expirationTime)
        {
            _cache.Set(key, value, expirationTime);
        }

        public void Remove(string key)
        {
            _cache.Remove(key);
        }
    }
}
