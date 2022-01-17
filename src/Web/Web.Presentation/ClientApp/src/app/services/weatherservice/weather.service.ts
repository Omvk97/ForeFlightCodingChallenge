import { Injectable } from '@angular/core';
import { WeatherData } from '../../interfaces/WeatherData';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class WeatherService {
  private weatherUrl = "localhost:5001/"
  constructor(
    private http: HttpClient,
  ) {}

  getWeather(icao: string): Observable<WeatherData> {
    const weatherData = of({
      City: "Roskilde",
      VisibilityDistanceSm: undefined,
      Temperature: undefined,
      PressureHg: undefined,
      WindDirection: 120,
      WindSpeedKts: 9,
      DateIssued: new Date(2021, 12, 24, 9, 20),
    });
    return weatherData;
  }
}
