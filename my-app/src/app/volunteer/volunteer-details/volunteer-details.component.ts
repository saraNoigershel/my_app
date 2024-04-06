import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormArray, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute ,Router} from '@angular/router';
import { Volunteer } from '../volunteer.model';
import { VolunteerServiceService } from '../volunteer-service.service'

@Component({
  selector: 'volunteer-details',
  templateUrl: './volunteer-details.component.html',
  styleUrls: ['./volunteer-details.component.scss']
})
export class VolunteerDetailsComponent implements OnInit {
  constructor(private _acr: ActivatedRoute, private vs: VolunteerServiceService,private router: Router) {

  }
  volunteerForm: FormGroup = new FormGroup({
    firstName: new FormControl('', [Validators.required, Validators.maxLength(15)]),
    lastName: new FormControl('', [Validators.required, Validators.maxLength(15)]),
    tel: new FormControl(''),
    Sun: new FormControl(false),
    Mon: new FormControl(false),
    Tues: new FormControl(false),
    Wedn: new FormControl(false),
    Thur: new FormControl(false)

  });
  value: Number = 0;
  private _Volunteer?: Volunteer;
  formNotValid: boolean = false;
  ngOnInit() {
    this.value = parseInt(this._acr.snapshot.paramMap.get('id') ?? '');
    this.vs.getById(this.value).subscribe(val => this.Volunteer = val);
  }



  public get Volunteer(): Volunteer | undefined {
    return this._Volunteer;
  }

 
  public set Volunteer(value: Volunteer | undefined) {
    this._Volunteer = value;
    if (value) {
      this.volunteerForm.setValue({firstName: this.Volunteer?.firstName,
         lastName: this.Volunteer?.lastName,
         tel:this.Volunteer?.tel,
         Sun:this.Volunteer?.days[0],
         Mon:this.Volunteer?.days[1],
         Tues:this.Volunteer?.days[2],
         Wedn:this.Volunteer?.days[3],
         Thur:this.Volunteer?.days[4]});
  }
    }
  
  saveVolunteer = () => {
    if (this.volunteerForm.valid) {
      console.log("save...");
      this.Volunteer!.firstName=this.volunteerForm!.value.firstName;
      this.Volunteer!.lastName=this.volunteerForm!.value.lastName;
      this.Volunteer!.tel=this.volunteerForm!.value.tel;
      this.Volunteer!.days[0]=this.volunteerForm!.value.Sun;
      this.Volunteer!.days[1]=this.volunteerForm!.value.Mon;
      this.Volunteer!.days[2]=this.volunteerForm!.value.Tues;
      this.Volunteer!.days[3]=this.volunteerForm!.value.Wedn;
      this.Volunteer!.days[4]=this.volunteerForm!.value.Thur;
      this.vs.update(this.Volunteer!).subscribe(val =>{this.isSaveSucceed(val)} );
      this.router.navigate(['/volunteers/volunteerList']);
    }
    else {
      this.formNotValid = true;
      console.log("not save...");
    }
  }
  isSaveSucceed = (val: boolean) => {
    if(val){

    }
    else{
      
    }

  }
}
