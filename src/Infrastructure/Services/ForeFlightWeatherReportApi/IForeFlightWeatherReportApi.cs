using System.Threading.Tasks;
using Application.Interfaces;
using Refit;

namespace Infrastructure.Services
{
    public interface IForeFlightWeatherReportApi
    {
        [Get("/weather/report/{icao}")]
        [Headers("ff-coding-exercise: 1")]
        Task<
    }
}