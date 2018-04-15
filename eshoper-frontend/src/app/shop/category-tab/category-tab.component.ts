import { Component, OnInit } from '@angular/core';
import { ProductDto } from '../../entities/productDto';
import { ProductService } from '../../data-service/product/product.service';
import { KeyValue } from '../../entities/key-value';
import { CategoryTabWithProductsViewModel } from '../../entities/Category-tab-Products-vm';

@Component({
  selector: 'app-category-tab',
  templateUrl: './category-tab.component.html',
  styleUrls: ['./category-tab.component.css']
})
export class CategoryTabComponent implements OnInit {
  tabHeaderList: string[];
  tabProductList: ProductDto[]; 

  constructor(private productService: ProductService) { }

  ngOnInit() {
    this.getTabHeaders();
  }

  getTabHeaders(){
    this.productService
        .getCategoriesForTabDisplay()
        .subscribe(
          (data: CategoryTabWithProductsViewModel) => {
            this.tabHeaderList = data.selectedCategoryList;
            this.tabProductList = data.firstListOfProducts;
          },
          (err: any) => console.log(err)
        );
  }

  getTabProductsByCategory(cat){
    this.productService.getTabProductsByCategory(cat)
    .subscribe(
      (data: ProductDto[]) => this.tabProductList = data,
      (err: any) => console.log(err)
    );
  }
}
