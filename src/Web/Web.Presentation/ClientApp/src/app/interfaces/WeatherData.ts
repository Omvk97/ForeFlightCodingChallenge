export interface WeatherData {
    weatherText?: String;
    icao?: String;
    dateIssued?: Date;
    issuedSince?: String;
    windSpeedKts?: Number;
    windDirection?: Number;
    visibilityDistanceSm?: Number;
    temperature?: Number;
    dewPoint?: String;
    pressureHg?: Number;
    humidity?: Number;
    densityAltitudeFt?: Number;
}