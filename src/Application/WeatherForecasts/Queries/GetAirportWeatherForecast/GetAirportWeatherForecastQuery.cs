using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.WeatherForecasts.Queries.GetAirportWeatherForecast
{
    public class GetAirportWeatherForecastQuery : IRequest<AirportWeatherReport>
    {
        public string ICAOCode { get; set; }
    }
    
    public class GetAirportWeatherForecastQueryHandler : IRequestHandler<GetAirportWeatherForecastQuery, AirportWeatherReport>
    {
        private readonly IAirportWeatherReportService _airportWeatherReportService;
        
        public GetAirportWeatherForecastQueryHandler(IAirportWeatherReportService airportWeatherReportService)
        {
            _airportWeatherReportService = airportWeatherReportService;
        }
        
        public async Task<AirportWeatherReport> Handle(GetAirportWeatherForecastQuery request, CancellationToken cancellationToken)
        {
            return await _airportWeatherReportService.Get(request.ICAOCode);
        }
    }
}