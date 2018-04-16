import { Component, OnInit } from '@angular/core';

import { ProductDto } from '../../entities/productDto';
import { ProductService } from '../../data-service/product/product.service';

@Component({
  selector: 'app-recommended-items',
  templateUrl: './recommended-items.component.html',
  styleUrls: ['./recommended-items.component.css']
})
export class RecommendedItemsComponent implements OnInit {
  recommendedItemList: ProductDto[][];
  recommendedItemList1: ProductDto[];
  recommendedItemList2: ProductDto[];

  constructor(private productService: ProductService) { }

  ngOnInit() {
    this.getProductVo();
  }

  getProductVo(): void{    
      this.productService.getRecommendedItems()
      .subscribe(
        (data: ProductDto[][] ) => this.recommendedItemList = data,
        (err: any) => console.log(err)
      );
  }

}
