import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Volunteer } from './volunteer.model';

@Injectable({
  providedIn: 'root'
})
export class VolunteerServiceService {

  constructor(private http: HttpClient) { }
  //get all volunteers from server
  getAll(): Observable<Volunteer[]> {
    return this.http.get<Volunteer[]>("/api/volunteer/all");

  }
  //get specipic volunteer by id
  getById(id: Number): Observable<Volunteer> {
    return this.http.get<Volunteer>(`api/volunteer/ById/${id}`);

  }
  //update details of secipic volunteer
  update(volunteer: Volunteer): Observable<boolean> {
    return this.http.put<boolean>('/api/volunteer/update', volunteer);
  }
}
