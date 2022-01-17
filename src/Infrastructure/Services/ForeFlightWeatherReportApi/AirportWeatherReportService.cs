using System;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Refit;

namespace Infrastructure.Services.ForeFlightWeatherReportApi
{
    public class AirportWeatherReportServiceService : IAirportWeatherReportService
    {
        private readonly IForeFlightWeatherReportApi _foreFlightWeatherReportApi;

        public AirportWeatherReportServiceService(IForeFlightWeatherReportApi foreFlightWeatherReportApi)
        {
            _foreFlightWeatherReportApi = foreFlightWeatherReportApi;
        }

        public async Task<AirportWeatherReport> Get(string ICAO)
        {
            try
            {
                var response = await _foreFlightWeatherReportApi.GetWeatherReport(ICAO);
                var report = response.Report;
                
                return new AirportWeatherReport(
                    VisibilityDistanceSm: report.Conditions.Visibility.DistanceSm,
                    Temperature: report.Conditions.TempC,
                    PressureHg: report.Conditions.PressureHg,
                    WindSpeedKts: report.Conditions.Wind.SpeedKts,
                    DateTime.Parse(report.Conditions.DateIssued));
            }
            catch (ApiException e)
            {
                // TODO: Proper error handling
                Console.WriteLine(e);
                throw;
            }
        }
    }
}