using MediatR;

namespace Application.WeatherForecasts.Queries
{
    public class GetAirportWeatherForecastQuery : IRequest<string>
    {
        public string ICAOCode { get; set; }
    }
    
    public class GetAirportWeatherForecastQueryHandler : IRequestHandler<GetAirportWeatherForecastQuery, >
}