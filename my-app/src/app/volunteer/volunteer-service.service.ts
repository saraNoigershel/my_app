import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Volunteer } from './volunteer.model';

@Injectable({
  providedIn: 'root'
})
export class VolunteerServiceService {

  constructor(private http: HttpClient) { }
  getAll(): Observable<Volunteer[]> {
    return this.http.get<Volunteer[]>("/api/volunteer/all");

  }
  getById(id: Number): Observable<Volunteer> {
    return this.http.get<Volunteer>(`api/volunteer/ById/${id}`);

  }
  update(volunteer: Volunteer): Observable<boolean> {
    return this.http.put<boolean>('/api/volunteer/update', volunteer);
  }
}
