import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Volunteer } from '../volunteer/volunteer.model';
import { Scheduling } from './scheduling.model';
@Injectable({
  providedIn: 'root'
})
export class SchedulingServiceService {

  constructor(private _http: HttpClient) { }
  getVoluteersByDay(day: Number): Observable<Volunteer[]> {
    return this._http.get<Volunteer[]>(`/api/scheduling/ByDay/${day}`);

  }
  getScheduling(): Observable<Volunteer[][]> {
    return this._http.get<Volunteer[][]>("/api/scheduling/all");
  }
  saveChosenScheduling(scheduling: Scheduling): Observable<boolean> {
    return this._http.put<boolean>("/api/scheduling/save", scheduling);


  }
  getChosenScheduling(): Observable<Scheduling> {
    return this._http.get<Scheduling>("/api/scheduling/getChosen");


  }
  
}
