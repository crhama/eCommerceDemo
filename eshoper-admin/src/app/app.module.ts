import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { MaintenanceModule } from './maintenance/maintenance.module';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { DashboardComponent } from './dashboard/dashboard.component';



@NgModule({
  declarations: [
    AppComponent,
    SidebarComponent,
    DashboardComponent
  ],
  imports: [
    BrowserModule, 
    HttpClientModule,
    RouterModule.forRoot([
      { path: '', component: DashboardComponent }   
    ]),
    MaintenanceModule    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
