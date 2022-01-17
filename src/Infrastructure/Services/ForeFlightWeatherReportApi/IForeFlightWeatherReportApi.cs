using System.Threading.Tasks;
using Infrastructure.Services.ForeFlightWeatherReportApi;
using Refit;

namespace Infrastructure.Services
{
    public interface IForeFlightWeatherReportApi
    {
        [Get("/weather/report/{icao}")]
        [Headers("ff-coding-exercise: 1")]
        Task<ForeFlightAirportWeatherReport> GetWeatherReport(string icao);
    }
}