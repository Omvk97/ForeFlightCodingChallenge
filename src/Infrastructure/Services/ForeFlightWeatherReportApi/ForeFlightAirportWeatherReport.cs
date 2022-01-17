using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Infrastructure.Services.ForeFlightWeatherReportApi
{
    public partial class ForeFlightAirportWeatherReport
    {
        [JsonProperty("report")]
        public Report Report { get; set; }
    }

    public partial class Report
    {
        [JsonProperty("conditions")]
        public Conditions Conditions { get; set; }

        [JsonProperty("forecast")]
        public Forecast Forecast { get; set; }

        [JsonProperty("windsAloft")]
        public ReportWindsAloft WindsAloft { get; set; }
    }

    public partial class Conditions
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
        public long ElevationFt { get; set; }

        [JsonProperty("tempC")]
        public long TempC { get; set; }

        [JsonProperty("dewpointC")]
        public long DewpointC { get; set; }

        [JsonProperty("pressureHg")]
        public double PressureHg { get; set; }

        [JsonProperty("densityAltitudeFt")]
        public long DensityAltitudeFt { get; set; }

        [JsonProperty("relativeHumidity")]
        public long RelativeHumidity { get; set; }

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

    public partial class CloudLayer
    {
        [JsonProperty("coverage")]
        public Coverage Coverage { get; set; }

        [JsonProperty("altitudeFt")]
        public long AltitudeFt { get; set; }

        [JsonProperty("ceiling")]
        public bool Ceiling { get; set; }
    }

    public partial class ConditionsVisibility
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

    public partial class Wind
    {
        [JsonProperty("speedKts")]
        public long SpeedKts { get; set; }

        [JsonProperty("direction")]
        public long Direction { get; set; }

        [JsonProperty("from")]
        public long From { get; set; }

        [JsonProperty("variable")]
        public bool Variable { get; set; }
    }

    public partial class Forecast
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
        public long ElevationFt { get; set; }

        [JsonProperty("conditions")]
        public List<Condition> Conditions { get; set; }
    }

    public partial class Condition
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
        public long ElevationFt { get; set; }

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

    public partial class ConditionVisibility
    {
        [JsonProperty("distanceSm")]
        public double DistanceSm { get; set; }

        [JsonProperty("prevailingVisSm")]
        public double PrevailingVisSm { get; set; }
    }

    public partial class ReportWindsAloft
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

    public partial class WindsAloftElement
    {
        [JsonProperty("validTime")]
        public string ValidTime { get; set; }

        [JsonProperty("period")]
        public Period Period { get; set; }

        [JsonProperty("windTemps")]
        public Dictionary<string, WindTemp> WindTemps { get; set; }
    }

    public partial class WindTemp
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

    public enum Coverage { Bkn, Few, Sct };

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                CoverageConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class CoverageConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Coverage) || t == typeof(Coverage?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "bkn":
                    return Coverage.Bkn;
                case "few":
                    return Coverage.Few;
                case "sct":
                    return Coverage.Sct;
            }
            throw new Exception("Cannot unmarshal type Coverage");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Coverage)untypedValue;
            switch (value)
            {
                case Coverage.Bkn:
                    serializer.Serialize(writer, "bkn");
                    return;
                case Coverage.Few:
                    serializer.Serialize(writer, "few");
                    return;
                case Coverage.Sct:
                    serializer.Serialize(writer, "sct");
                    return;
            }
            throw new Exception("Cannot marshal type Coverage");
        }

        public static readonly CoverageConverter Singleton = new CoverageConverter();
    }
}
