using Microsoft.AspNetCore.Mvc;

namespace SearchKernelProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("/get")]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}