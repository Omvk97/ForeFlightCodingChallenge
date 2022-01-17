using System;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Polly;
using Refit;

namespace Infrastructure.Services.ForeFlightWeatherReportApi
{
    public class AirportWeatherReportService : IAirportWeatherReportService
    {
        private readonly IForeFlightWeatherReportApi _foreFlightWeatherReportApi;

        private readonly IMemoryCache _cache;

        private ILogger<AirportWeatherReportService> _logger;

        public AirportWeatherReportService(
            IForeFlightWeatherReportApi foreFlightWeatherReportApi,
            IMemoryCache cache,
            ILogger<AirportWeatherReportService> logger)
        {
            _foreFlightWeatherReportApi = foreFlightWeatherReportApi;
            _cache = cache;
            _logger = logger;
        }

        public async Task<AirportWeatherReport> Get(string ICAO)
        {
            var weatherReportExistsInCache = _cache.TryGetValue(ICAO, out AirportWeatherReport cachedWeatherReport);
            if (weatherReportExistsInCache)
            {
                _logger.LogInformation("Fetched from memory cache");
                return cachedWeatherReport;
            }

            var weatherReport = await FetchWeatherReport(ICAO);

            SaveInCache(ICAO, weatherReport);
            return weatherReport;
        }

        private async Task<AirportWeatherReport> FetchWeatherReport(string ICAO)
        {
            var weatherReport = await GetWeatherReport(ICAO);

            var airPortWeatherReport = new AirportWeatherReport(
                Icao: ICAO,
                WeatherText: weatherReport.Conditions.Text,
                DateIssued: DateTime.Parse(weatherReport.Conditions.DateIssued),
                WindSpeedKts: weatherReport.Conditions.Wind.SpeedKts,
                WindDirection: weatherReport.Conditions.Wind.Direction,
                VisibilityDistanceSm: weatherReport.Conditions.Visibility.DistanceSm,
                Temperature: weatherReport.Conditions.TempC,
                DewPoint: weatherReport.Conditions.DewpointC,
                PressureHg: weatherReport.Conditions.PressureHg,
                Humidity: weatherReport.Conditions.RelativeHumidity,
                DensityAltitudeFt: weatherReport.Conditions.DensityAltitudeFt);

            return airPortWeatherReport;
        }

        private void SaveInCache(string ICAO, AirportWeatherReport airPortWeatherReport)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(DateTimeOffset.Now.AddMinutes(5));

            _cache.Set(ICAO, airPortWeatherReport, cacheEntryOptions);
        }

        private async Task<Report> GetWeatherReport(string ICAO)
        {
            // Using simple retry pattern to resolve simple network errors aka. "It was just a blip"
            var weatherReport = await Policy
                .Handle<ApiException>()
                .RetryAsync(3,
                    onRetry: ((exception, retryCount) =>
                    {
                        _logger.LogError(exception, "Foreflight weather API failed. Retrycount: {0}", retryCount);
                    }))
                .ExecuteAsync(async () => await _foreFlightWeatherReportApi.GetWeatherReport(ICAO));
            return weatherReport.Report;
        }
    }
}