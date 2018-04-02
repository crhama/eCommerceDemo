import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProductService } from './product/product.service';
import { MaintenanceService } from './maintenance/maintenance.service';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [],
  providers: [
    ProductService, 
    MaintenanceService
  ]
})
export class DataServiceModule { }
