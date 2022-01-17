
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IAirportWeatherReportService
    {
        Task<AirportWeatherReport> Get(string ICAO);
    }
}