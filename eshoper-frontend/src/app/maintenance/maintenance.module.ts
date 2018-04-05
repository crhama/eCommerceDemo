import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { MainMaintComponent } from './main-maint/main-maint.component';
import { EditMaintComponent } from './edit-maint/edit-maint.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { EntityListMaintComponent } from './entity-list-maint/entity-list-maint.component';
import { ProductEditComponent } from './product-edit/product-edit.component';


@NgModule({
  imports: [
    CommonModule, 
    RouterModule.forChild([
      { path: 'maintenance', component: MainMaintComponent },
      { path: 'edit-maintenance', component: EditMaintComponent },
      { path: 'maintenance/:ename', component: EntityListMaintComponent },
      { path: 'maintenance/product/new', component: ProductEditComponent }
    ])
  ],
  declarations: [
    MainMaintComponent, 
    EditMaintComponent, 
    DashboardComponent, 
    EntityListMaintComponent, ProductEditComponent
  ]
})
export class MaintenanceModule { }
