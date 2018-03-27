import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProductService } from './product/product.service';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [],
  providers: [
    ProductService
  ]
})
export class DataServiceModule { }