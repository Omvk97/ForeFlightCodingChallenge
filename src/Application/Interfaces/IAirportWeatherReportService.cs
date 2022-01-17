
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IAirportWeatherReport
    {
        Task<AirportWeatherReport> Get(string ICAO);
    }
}