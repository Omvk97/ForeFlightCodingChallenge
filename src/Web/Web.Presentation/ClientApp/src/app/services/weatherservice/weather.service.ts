import { Injectable } from '@angular/core';
import { WeatherData } from '../../interfaces/WeatherData';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class WeatherService {
  constructor(private http: HttpClient) {}

  getWeather(icao: string): Observable<WeatherData> {
    var weatherUrl = 'https://localhost:5001/weatherforecast?ICAOCode=' + icao;
    const weatherData = this.http
      .get<WeatherData>(weatherUrl)
      .pipe(
        tap(_ => console.log('fetched weahter')),
        catchError(this.handleError<WeatherData>('getWeather', undefined)));
    return weatherData;
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      // TODO: better logging
      console.error(error); // log to console instead

      return of(result as T);
    };
  }
}
