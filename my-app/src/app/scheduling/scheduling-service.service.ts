import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Volunteer } from '../volunteer/volunteer.model';
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
  saveScheduling(Scheduling: number[]): Observable<boolean> {
    return this._http.put<boolean>("api/scheduling/save", Scheduling);


  }
  
}
