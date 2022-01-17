using System;

namespace Domain.Entities
{
    public record AirportWeatherReport(
        string Icao,
        string WeatherText,
        DateTime DateIssued,
        double WindSpeedKts,
        int WindDirection,
        double VisibilityDistanceSm,
        double Temperature,
        double DewPoint,
        double PressureHg,
        int Humidity,
        double DensityAltitudeFt
    );
}