import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { WeatherData } from '../interfaces/WeatherData';
import { WeatherService } from '../services/weatherservice/weather.service';
import { FormBuilder, Validators } from '@angular/forms';
import * as moment from 'moment';

@Component({
  selector: 'app-weatherdata',
  templateUrl: './weatherdata.component.html',
  styleUrls: ['./weatherdata.component.css'],
})
export class WeatherdataComponent implements OnInit {
  weatherData: WeatherData = {
    weatherText: undefined,
    icao: undefined,
    dateIssued: undefined,
    windSpeedKts: undefined,
    windDirection: undefined,
    visibilityDistanceSm: undefined,
    temperature: undefined,
    dewPoint: undefined,
    pressureHg: undefined,
    humidity: undefined,
    densityAltitudeFt: undefined
  };

  icaoForm = this.fb.group({
    icao: [
      null,
      Validators.compose([
        Validators.required,
        Validators.minLength(4),
        Validators.maxLength(4),
      ]),
    ],
  });

  constructor(
    private weatherService: WeatherService,
    private fb: FormBuilder
  ) {}

  ngOnInit(): void {}

  getWeather(): void {
    var icaoInput = this.icaoForm.get('icao')?.value;
    if (!icaoInput) return;

    this.weatherService.getWeather(icaoInput).subscribe((response: WeatherData) => {
      this.weatherData = response
      this.weatherData.issuedSince = moment(response.dateIssued).format('MMMM Do YYYY, h:mm:ss a')
    });
  }
}
