import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
const ROUTES:Routes=[
  {path: "volunteers", loadChildren:()=>import("./volunteer/volunteer.module").then(m=>m.VolunteerModule)},
  {path:"scheduling", loadChildren:()=>import("./scheduling/scheduling.module").then(m=>m.SchedulingModule)}

]

@NgModule({
  declarations: [
    AppComponent,
    
  ],
  imports: [
    BrowserModule,RouterModule.forRoot(ROUTES,{useHash:true})

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
