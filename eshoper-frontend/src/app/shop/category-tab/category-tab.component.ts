import { Component, OnInit } from '@angular/core';
import { ProductDto } from '../../entities/productDto';
import { ProductService } from '../../data-service/product/product.service';

@Component({
  selector: 'app-category-tab',
  templateUrl: './category-tab.component.html',
  styleUrls: ['./category-tab.component.css']
})
export class CategoryTabComponent implements OnInit {
  tshirtTabList: ProductDto[];
  blazersTabList: ProductDto[];
  sunglassTabList: ProductDto[];
  kidsTabList: ProductDto[];

  constructor(private productService: ProductService) { }

  ngOnInit() {
    this.getProductByCategory();
    this.blazersTabList = this.tshirtTabList;
    this.sunglassTabList = this.tshirtTabList;
    this.kidsTabList = this.tshirtTabList;
  }

  getProductByCategory(): void{
    this.productService.getProductByCategory("1/products")
      .subscribe(
        (data: ProductDto[]) => this.tshirtTabList = data,
        (err: any) => console.log(err)
      )
  }

}
