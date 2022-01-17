using System.Collections.Generic;
using Newtonsoft.Json;

namespace Infrastructure.Services.ForeFlightWeatherReportApi
{
    public class ForeFlightAirportWeatherReport
    {
        [JsonProperty("report")]
        public Report Report { get; set; }
    }

    public class Report
    {
        [JsonProperty("conditions")]
        public Conditions Conditions { get; set; }

        [JsonProperty("forecast")]
        public Forecast Forecast { get; set; }

        [JsonProperty("windsAloft")]
        public ReportWindsAloft WindsAloft { get; set; }
    }

    public class Conditions
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("ident")]
        public string Ident { get; set; }

        [JsonProperty("dateIssued")]
        public string DateIssued { get; set; }

        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lon")]
        public double Lon { get; set; }

        [JsonProperty("elevationFt")]
        public double ElevationFt { get; set; }

        [JsonProperty("tempC")]
        public double TempC { get; set; }

        [JsonProperty("dewpointC")]
        public double DewpointC { get; set; }

        [JsonProperty("pressureHg")]
        public double PressureHg { get; set; }

        [JsonProperty("densityAltitudeFt")]
        public long DensityAltitudeFt { get; set; }

        [JsonProperty("relativeHumidity")]
        public int RelativeHumidity { get; set; }

        [JsonProperty("flightRules")]
        public string FlightRules { get; set; }

        [JsonProperty("cloudLayers")]
        public List<CloudLayer> CloudLayers { get; set; }

        [JsonProperty("cloudLayersV2")]
        public List<CloudLayer> CloudLayersV2 { get; set; }

        [JsonProperty("weather")]
        public List<object> Weather { get; set; }

        [JsonProperty("visibility")]
        public ConditionsVisibility Visibility { get; set; }

        [JsonProperty("wind")]
        public Wind Wind { get; set; }
    }

    public class CloudLayer
    {
        [JsonProperty("coverage")]
        public string Coverage { get; set; }

        [JsonProperty("altitudeFt")]
        public double AltitudeFt { get; set; }

        [JsonProperty("ceiling")]
        public bool Ceiling { get; set; }
    }

    public class ConditionsVisibility
    {
        [JsonProperty("distanceSm")]
        public double DistanceSm { get; set; }

        [JsonProperty("distanceQualifier")]
        public long DistanceQualifier { get; set; }

        [JsonProperty("prevailingVisSm")]
        public double PrevailingVisSm { get; set; }

        [JsonProperty("prevailingVisDistanceQualifier")]
        public long PrevailingVisDistanceQualifier { get; set; }
    }

    public class Wind
    {
        [JsonProperty("speedKts")]
        public double SpeedKts { get; set; }

        [JsonProperty("direction")]
        public int Direction { get; set; }

        [JsonProperty("from")]
        public long From { get; set; }

        [JsonProperty("variable")]
        public bool Variable { get; set; }
    }

    public class Forecast
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("ident")]
        public string Ident { get; set; }

        [JsonProperty("dateIssued")]
        public string DateIssued { get; set; }

        [JsonProperty("period")]
        public Period Period { get; set; }

        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lon")]
        public double Lon { get; set; }

        [JsonProperty("elevationFt")]
        public double ElevationFt { get; set; }

        [JsonProperty("conditions")]
        public List<Condition> Conditions { get; set; }
    }

    public class Condition
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("dateIssued")]
        public string DateIssued { get; set; }

        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lon")]
        public double Lon { get; set; }

        [JsonProperty("elevationFt")]
        public double ElevationFt { get; set; }

        [JsonProperty("relativeHumidity")]
        public long RelativeHumidity { get; set; }

        [JsonProperty("flightRules")]
        public string FlightRules { get; set; }

        [JsonProperty("cloudLayers")]
        public List<CloudLayer> CloudLayers { get; set; }

        [JsonProperty("cloudLayersV2")]
        public List<CloudLayer> CloudLayersV2 { get; set; }

        [JsonProperty("weather")]
        public List<string> Weather { get; set; }

        [JsonProperty("visibility")]
        public ConditionVisibility Visibility { get; set; }

        [JsonProperty("wind")]
        public Wind Wind { get; set; }

        [JsonProperty("period")]
        public Period Period { get; set; }

        [JsonProperty("change", NullValueHandling = NullValueHandling.Ignore)]
        public string Change { get; set; }
    }

    public partial class Period
    {
        [JsonProperty("dateStart")]
        public string DateStart { get; set; }

        [JsonProperty("dateEnd")]
        public string DateEnd { get; set; }
    }

    public class ConditionVisibility
    {
        [JsonProperty("distanceSm")]
        public double DistanceSm { get; set; }

        [JsonProperty("prevailingVisSm")]
        public double PrevailingVisSm { get; set; }
    }

    public class ReportWindsAloft
    {
        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lon")]
        public double Lon { get; set; }

        [JsonProperty("dateIssued")]
        public string DateIssued { get; set; }

        [JsonProperty("windsAloft")]
        public List<WindsAloftElement> WindsAloft { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }
    }

    public class WindsAloftElement
    {
        [JsonProperty("validTime")]
        public string ValidTime { get; set; }

        [JsonProperty("period")]
        public Period Period { get; set; }

        [JsonProperty("windTemps")]
        public Dictionary<string, WindTemp> WindTemps { get; set; }
    }

    public class WindTemp
    {
        [JsonProperty("directionFromTrue")]
        public long DirectionFromTrue { get; set; }

        [JsonProperty("knots")]
        public long Knots { get; set; }

        [JsonProperty("celsius")]
        public long Celsius { get; set; }

        [JsonProperty("altitude")]
        public long Altitude { get; set; }

        [JsonProperty("isLightAndVariable")]
        public bool IsLightAndVariable { get; set; }

        [JsonProperty("isGreaterThan199Knots")]
        public bool IsGreaterThan199Knots { get; set; }

        [JsonProperty("turbulence")]
        public bool Turbulence { get; set; }

        [JsonProperty("icing")]
        public bool Icing { get; set; }
    }
}
