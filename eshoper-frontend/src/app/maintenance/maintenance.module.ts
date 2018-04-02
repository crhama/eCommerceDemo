import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { MainMaintComponent } from './main-maint/main-maint.component';
import { EditMaintComponent } from './edit-maint/edit-maint.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { EntityListMaintComponent } from './entity-list-maint/entity-list-maint.component';


@NgModule({
  imports: [
    CommonModule, 
    RouterModule.forChild([
      { path: 'maintenance', component: MainMaintComponent },
      { path: 'edit-maintenance', component: EditMaintComponent },
      { path: 'entity-list-maintenance', component: EntityListMaintComponent }
    ])
  ],
  declarations: [
    MainMaintComponent, 
    EditMaintComponent, 
    DashboardComponent, 
    EntityListMaintComponent
  ]
})
export class MaintenanceModule { }
