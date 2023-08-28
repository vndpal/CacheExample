using CacheExample.Interface;
using CacheExample.Service;
using Microsoft.AspNetCore.Mvc;

namespace CacheExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExampleController : ControllerBase
    {        
        private readonly ExampleService _exampleService;

        public ExampleController(ILogger<ExampleController> logger, ExampleService exampleService)
        {
            _exampleService = exampleService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<string> Get()
        {
            return await _exampleService.GetValueFromCache("testKey");
        }
    }
}