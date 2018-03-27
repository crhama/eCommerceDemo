import { Component, OnInit } from '@angular/core';
import { ProductVo } from '../entities/productvo';
import { ProductService } from '../data-service/product/product.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  featureItemList: ProductVo[];

  constructor(private productService: ProductService) { }

  ngOnInit() {
    this.getProductVo();
  }

  getProductVo(): void{
    this.productService
        .getComponentProductItems("FeatureItems")
        .subscribe(
          (data: ProductVo[]) => this.featureItemList = data,
          (err: any) => console.log(err)
        );
  }

}
