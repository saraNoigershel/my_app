import { Component } from '@angular/core';
import { Volunteer } from '../volunteer/volunteer.model';
import { SchedulingServiceService } from './scheduling-service.service';
import { FormArray, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'scheduling',
  templateUrl: './scheduling.component.html',
  styleUrls: ['./scheduling.component.scss']
})
export class SchedulingComponent {
  constructor(private ss: SchedulingServiceService) {

  }
  ngOnInit() {
    this.ss.getScheduling().subscribe(val => this.volunteers_scheduling = val)
    this.schedulingForm.setValue({ Sun: this.chosen[0], Mon: this.chosen[1], Tues: this.chosen[2], Wedn: this.chosen[3], Thur: this.chosen[4] })

  }
  schedulingForm: FormGroup = new FormGroup({

    Sun: new FormControl(-1),
    Mon: new FormControl(-1),
    Tues: new FormControl(-1),
    Wedn: new FormControl(-1),
    Thur: new FormControl(-1)
  });
  Days: string[] = ["Sun", "Mon", "Tues", "Wedn", "Thur"];
  chosen: number[] = [-1, -1, -1, -1, -1];
  volunteers_scheduling: Volunteer[][] = [[], [], [], [], []];
  getSchedulingForDay = (day: number): Volunteer[] => {
    return this.volunteers_scheduling[day];
  }
  save_schduling() {
    this.chosen[0]=this.schedulingForm.value.Sun;
    this.chosen[1]=this.schedulingForm.value.Mon;

    this.chosen[2]=this.schedulingForm.value.Tues;

    this.chosen[3]=this.schedulingForm.value.Wedn;

    this.chosen[4]=this.schedulingForm.value.Thur;

    this.ss.saveScheduling(this.chosen);

  }
  saveSchedulingForDay(day: number, volunteer: Volunteer) {
    this.chosen[day] = volunteer.id;

  }





}
