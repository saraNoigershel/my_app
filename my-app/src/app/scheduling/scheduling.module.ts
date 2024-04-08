import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SchedulingComponent } from './scheduling.component';
import { RouterModule,Routes } from '@angular/router';
import {HttpClientModule} from '@angular/common/http';
import { SchedulingServiceService } from './scheduling-service.service';
import { ReactiveFormsModule } from '@angular/forms';


const ROUTES:Routes=[
  {path:"",component:SchedulingComponent},
  {path:"scheduling",component:SchedulingComponent}
]
@NgModule({
  declarations: [
    SchedulingComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(ROUTES),
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers:[SchedulingServiceService]
})
export class SchedulingModule { }
