import { Component, OnInit } from '@angular/core';
import { VolunteerServiceService } from '../volunteer-service.service';
import { Volunteer } from '../volunteer.model';
import { Router } from '@angular/router';
@Component({
  selector: 'volunteer-list',
  templateUrl: './volunteer-list.component.html',
  styleUrls: ['./volunteer-list.component.scss']
})
export class VolunteerListComponent implements OnInit {
  constructor(private vs: VolunteerServiceService, private router: Router) {

  }
  ngOnInit() {
    this.vs.getAll().subscribe(val => this.volunteers = val)

  }
  volunteers: Volunteer[] = [];
  editVolunteer = (volunteer: Volunteer) => {
     this.router.navigate(['/volunteers/volunteer-details',volunteer!.id]);

  }
  
  


}
