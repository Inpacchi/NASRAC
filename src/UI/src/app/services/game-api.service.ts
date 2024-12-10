import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { RaceLog } from '../models/race-log';
import { EnvironmentService } from './environment.service';

@Injectable({
  providedIn: 'root'
})
export class GameApiService {

  constructor(
    private http: HttpClient,
    private environment: EnvironmentService
  ) { }

  public getRaceLog(raceId: number): Promise<RaceLog> {
    this.http.get<RaceLog[]>(this.environment.apiUrl.concat(''))
  }
}
