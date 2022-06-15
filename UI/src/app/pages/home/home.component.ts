import { Component, OnInit } from '@angular/core';

import {OwlOptions} from 'ngx-owl-carousel-o';

import {Race} from '../../models/race';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  public loggedIn = false;
  public days: number = 0;
  public hours: number = 0;
  public minutes: number = 0;
  public seconds: number = 0;
  public endTime = new Date('14 June 2022 4:00:00 GMT-04:00').getTime();
  public premierSeriesName = 'Kraken Automotive NASRAC Cup Series';
  public seasonType = 'Regular Season';
  public raceName = 'Busch Light Clash at the Coliseum'
  public raceLogoUrl = 'assets/race-logos/2022/busch-light-clash.png';
  public previousRaceName = 'NASRAC Championship Weekend @ Phoenix'
  public previousRaceLogoUrl = 'assets/race-logos/2021/phoenix-championship.png';
  public firstPlaceDriver = 'Yovarni Yearwood';
  public secondPlaceDriver = 'Stefan Baggoo';
  public thirdPlaceDriver = 'Josh Sapienza';
  public currentRaceNumber: number = 1;
  public totalRaces: number = 36;
  public raceSchedule: Array<Race> = [
    {
      trackName: "Daytona International Speedway",
      raceName: "Bluegreen Vacations Duel",
      date: "February 11, 2022",
      url: "assets/race-logos/2021/bluegreen-vacations-duel.jpeg"
    },
    {
      trackName: "Daytona International Speedway",
      raceName: "Daytona 500",
      date: "February 14, 2022",
      url: "assets/race-logos/2021/daytona-500.jpeg"
    },
    {
      trackName: "Daytona International Speedway",
      raceName: "O'Reilly Auto Parts 253",
      date: "February 21, 2022",
      url: "assets/race-logos/2021/o-reilly-auto-parts-253.png"
    },
    {
      trackName: "Homestead-Miami Speedway",
      raceName: "Dixie Vodka 400",
      date: "February 28, 2022",
      url: "assets/race-logos/2021/dixie-vodka-400.png"
    },
    {
      trackName: "Las Vegas Motor Speedway",
      raceName: "Pennzoil 400",
      date: "March 7, 2022",
      url: "assets/race-logos/2021/pennzoil-400.png"
    },
    {
      trackName: "Phoenix Raceway",
      raceName: "Ruoff Mortgage 500",
      date: "March 14, 2022",
      url: "assets/race-logos/2021/ruoff-mortgage-500.png"
    }
  ]
  public carouselOptions: OwlOptions = {
    autoplay: true,
    autoHeight: true,
    center: false,
    loop: true,
    items:1,
    margin: 30,
    stagePadding: 0,
    nav: false,
    dots: true,
    responsive:{
      0:{
        items: 1
      },
      600:{
        items: 2
      },
      1000:{
        items: 3
      }
    }
  }

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
