import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductsComponent } from './products/products.component';
import { RouterModule } from '@angular/router';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { CheckoutComponent } from './checkout/checkout.component';
import { CartComponent } from './cart/cart.component';
import { CategoryComponent } from './category/category.component';
import { BrandComponent } from './brand/brand.component';
import { RecommendedItemsComponent } from './recommended-items/recommended-items.component';
import { CategoryTabComponent } from './category-tab/category-tab.component';
import { PriceRangeComponent } from './price-range/price-range.component';
import { ShippingComponent } from './shipping/shipping.component';

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild([
      { path: 'products', component: ProductsComponent },
      { path: 'productdetails', component: ProductDetailsComponent },
      { path: 'checkout', component: CheckoutComponent },
      { path: 'cart', component: CartComponent }
    ])
  ],
  declarations: [
    ProductsComponent, 
    ProductDetailsComponent, 
    CheckoutComponent, 
    CartComponent, 
    CategoryComponent, 
    BrandComponent, 
    RecommendedItemsComponent, 
    CategoryTabComponent, 
    PriceRangeComponent, 
    ShippingComponent
  ],
  exports: [
    BrandComponent,
    CategoryComponent,
    RecommendedItemsComponent,
    CategoryTabComponent,
    PriceRangeComponent, 
    ShippingComponent
  ]
})
export class ShopModule { }
