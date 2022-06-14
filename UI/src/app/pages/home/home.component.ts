import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  public loggedIn = true;
  public days: number = 0;
  public hours: number = 0;
  public minutes: number = 0;
  public seconds: number = 0;
  public endTime = new Date('14 June 2022 4:00:00 GMT-04:00').getTime();
  public premierSeriesName = 'Kraken Automotive NASRAC Cup Series';
  public seasonType = 'Regular Season';
  public raceName = 'Busch Light Clash at the Coliseum'
  public raceLogoUrl = 'assets/race-logos/2022/busch_light_clash.png';
  public currentRaceNumber: number = 1;
  public totalRaces: number = 36;

  constructor() { }

  ngOnInit(): void {
    setInterval(() => this.timer(), 1000);
  }

  public timer() {
    const timeLeft = (this.endTime - new Date().getTime()) / 1000;

    this.days = Math.floor(timeLeft / 86400);
    this.hours = Math.floor((timeLeft - (this.days * 86400)) / 3600);
    this.minutes = Math.floor((timeLeft - (this.days * 86400) - (this.hours * 3600)) / 60);
    this.seconds = Math.floor((timeLeft - (this.days * 86400) - (this.hours * 3600) - (this.minutes * 60)));
  }
}
