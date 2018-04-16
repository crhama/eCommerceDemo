import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { ProductListComponent } from './product-list/product-list.component';
import { BrandListComponent } from './brand-list/brand-list.component';
import { CategoryListComponent } from './category-list/category-list.component';
import { ImageListComponent } from './image-list/image-list.component';
import { MaintenanceService } from './maintenance.service';

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild([      
      { path: 'brands', component: BrandListComponent },
      { path: 'categories', component: CategoryListComponent },
      { path: 'images', component: BrandListComponent },
      { path: 'products', component: ProductListComponent }
    ])
  ],
  declarations: [
    ProductListComponent, 
    BrandListComponent, 
    CategoryListComponent, 
    ImageListComponent
  ], 
  providers: [
    MaintenanceService
  ]
})
export class MaintenanceModule { }
