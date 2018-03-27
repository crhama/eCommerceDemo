import { Component, OnInit } from '@angular/core';

import { ProductVo } from '../../entities/productvo';
import { ProductService } from '../../data-service/product/product.service';

@Component({
  selector: 'app-recommended-items',
  templateUrl: './recommended-items.component.html',
  styleUrls: ['./recommended-items.component.css']
})
export class RecommendedItemsComponent implements OnInit {
  recommendedItemList: ProductVo[][];
  recommendedItemList1: ProductVo[];
  recommendedItemList2: ProductVo[];

  constructor(private productService: ProductService) { }

  ngOnInit() {
    this.getProductVo();
  }

  getProductVo(): void{    
      this.productService.getRecommendedItems("RecommendedItems")
      .subscribe(
        (data:ProductVo[][] ) => this.recommendedItemList = data,
        (err: any) => console.log(err)
      );
  }

}
