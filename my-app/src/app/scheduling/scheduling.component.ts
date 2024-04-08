import { Component } from '@angular/core';
import { Volunteer } from '../volunteer/volunteer.model';
import { SchedulingServiceService } from './scheduling-service.service';
import { FormArray, FormControl, FormGroup, Validators } from '@angular/forms';
import { Scheduling } from './scheduling.model';

@Component({
  selector: 'scheduling',
  templateUrl: './scheduling.component.html',
  styleUrls: ['./scheduling.component.scss']
})
export class SchedulingComponent {
  constructor(private ss: SchedulingServiceService) {

  }
  ngOnInit() {
    this.ss.getScheduling().subscribe(val => this.volunteers_scheduling = val);//get the scheduling array
    this.ss.getChosenScheduling().subscribe(val=>this.chosen=val);//get the array of ids of the volunteers to be chosen each day
    this.schedulingForm.setValue({ Sun: this.chosen.chosen[0], Mon: this.chosen.chosen[1], Tues: this.chosen.chosen[2], Wedn: this.chosen.chosen[3], Thur: this.chosen.chosen[4] })
    //set the form control values

  }
  schedulingForm: FormGroup = new FormGroup({

    "Sun": new FormControl(-1),
    "Mon": new FormControl(-1),
    "Tues": new FormControl(-1),
    "Wedn": new FormControl(-1),
    "Thur": new FormControl(-1)
  });
  Days: string[] = ["Sun", "Mon", "Tues", "Wedn", "Thur"];
  //array of ids to sign which volunteer was chosen for each day
  chosen:Scheduling=new Scheduling();
  volunteers_scheduling: Volunteer[][] = [[], [], [], [], []];
  getSchedulingForDay = (day: number): Volunteer[] => {
    return this.volunteers_scheduling[day];
  }
  save_schduling() {
    this.chosen.chosen[0] = parseInt(this.schedulingForm.value.Sun);
    this.chosen.chosen[1] = parseInt(this.schedulingForm.value.Mon);
    this.chosen.chosen[2] = parseInt(this.schedulingForm.value.Tues);
    this.chosen.chosen[3] = parseInt(this.schedulingForm.value.Wedn);
    this.chosen.chosen[4] = parseInt(this.schedulingForm.value.Thur);

    this.ss.saveChosenScheduling(this.chosen);

  }






}
