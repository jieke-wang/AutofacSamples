using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApiSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly Llibrary.Service.Service3.IService _service3;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, Llibrary.Service.Service3.IService service3)
        {
            _logger = logger;
            this._service3 = service3;
        }

        [HttpGet]
        public void Get()
        {
            _service3.ShowService();
            _service3.Plus(1, 2);
        }
    }
}
