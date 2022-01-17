using System.Threading.Tasks;
using Application.WeatherForecasts.Queries.GetAirportWeatherForecast;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ApiControllerBase
    {
        [HttpGet]
        public Task<AirportWeatherReport> Get(string ICAOCode)
        {
            return Mediator.Send(new GetAirportWeatherForecastQuery
            {
                ICAOCode = ICAOCode
            });
        }
    }
}