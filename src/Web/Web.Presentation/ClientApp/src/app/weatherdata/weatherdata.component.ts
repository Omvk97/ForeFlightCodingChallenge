import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-weatherdata',
  templateUrl: './weatherdata.component.html',
  styleUrls: ['./weatherdata.component.css']
})
export class WeatherdataComponent implements OnInit {
  windSpeedKts = ""
  
  constructor() { }

  ngOnInit(): void {
  }

}
