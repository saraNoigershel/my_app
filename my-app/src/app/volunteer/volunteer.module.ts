import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { VolunteerListComponent } from './volunteer-list/volunteer-list.component';
import { VolunteerDetailsComponent } from './volunteer-details/volunteer-details.component';
import {RouterModule,Routes } from '@angular/router';
import {HttpClientModule} from '@angular/common/http';
import { VolunteerServiceService } from './volunteer-service.service';
import { ReactiveFormsModule } from '@angular/forms';

const ROUTES:Routes=[
  {path:"",component:VolunteerListComponent},
  {path:"volunteerList",component:VolunteerListComponent},
  {path:'volunteer-details/:id',component:VolunteerDetailsComponent}
 
]
@NgModule({
  declarations: [VolunteerListComponent,
    VolunteerDetailsComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(ROUTES),
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers:[VolunteerServiceService]
})
export class VolunteerModule { }

