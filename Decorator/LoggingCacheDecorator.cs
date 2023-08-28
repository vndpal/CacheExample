using CacheExample.Interface;

namespace CacheExample.Decorator
{
    public class LoggingCacheDecorator : ICache
    {
        private readonly ICache _cache;
        private readonly ILogger<LoggingCacheDecorator> _logger;

        public LoggingCacheDecorator(ICache cache, ILogger<LoggingCacheDecorator> logger)
        {
            _cache = cache;
            _logger = logger;
        }

        public T Get<T>(string key)
        {
            var value = _cache.Get<T>(key);

            if (value == null)
            {
                _logger.LogInformation($"Cache miss for key: {key}");
            }
            else
            {
                _logger.LogInformation($"Cache hit for key: {key}");
            }

            return value;
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
