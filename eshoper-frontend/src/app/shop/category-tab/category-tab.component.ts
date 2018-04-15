import { Component, OnInit } from '@angular/core';
import { ProductDto } from '../../entities/productDto';
import { ProductService } from '../../data-service/product/product.service';
import { KeyValue } from '../../entities/key-value';

@Component({
  selector: 'app-category-tab',
  templateUrl: './category-tab.component.html',
  styleUrls: ['./category-tab.component.css']
})
export class CategoryTabComponent implements OnInit {
  tabList: KeyValue[];
  tshirtTabList: ProductDto[];
  blazersTabList: ProductDto[];
  sunglassTabList: ProductDto[];
  kidsTabList: ProductDto[];

  constructor(private productService: ProductService) { }

  ngOnInit() {
    this.getTabHeaders();


    this.getProductByCategory();
    this.blazersTabList = this.tshirtTabList;
    this.sunglassTabList = this.tshirtTabList;
    this.kidsTabList = this.tshirtTabList;
  }

  getTabHeaders(){
    this.productService
        .getCategoriesForTabDisplay()
        .subscribe(
          (data: KeyValue[]) => this.tabList = data,
          (err: any) => console.log(err)
        );
  }

  getTabProducts(id){

  }

  getProductByCategory(): void{
    this.productService.getProductByCategory("1/products")
      .subscribe(
        (data: ProductDto[]) => this.tshirtTabList = data,
        (err: any) => console.log(err)
      )
  }

}
