import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-race-log',
  templateUrl: './race-log.component.html',
  styleUrls: ['./race-log.component.scss']
})
export class RaceLogComponent implements OnInit {
  raceLogs: RaceLog[] = [];

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http.get<RaceLog[]>('/api/race-log')
      .subscribe(logs => this.raceLogs = logs);
  }
}

}
