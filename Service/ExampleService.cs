using CacheExample.Interface;

namespace CacheExample.Service
{
    public class ExampleService
    {
        private readonly ICache _cache;
         
        public ExampleService(ICache cache)
        {
            _cache = cache;
        }

        public async Task<string> GetValueFromCache(string key)
        {
            var value = _cache.Get<string>(key);

            if (value == null)
            {
                value = await ExpensiveDatabaseCall();
                _cache.Set(key, value, TimeSpan.FromMinutes(10));
            }

            return value;
        }

        private async Task<string> ExpensiveDatabaseCall()
        {
            await Task.Delay(TimeSpan.FromSeconds(10));            
            return "Cached Value";
        }
    }
}
