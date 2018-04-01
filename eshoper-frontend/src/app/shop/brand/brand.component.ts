import { Component, OnInit } from '@angular/core';
import { BrandDto } from '../../entities/brandDto';
import { ProductService } from '../../data-service/product/product.service';

@Component({
  selector: 'app-brand',
  templateUrl: './brand.component.html',
  styleUrls: ['./brand.component.css']
})
export class BrandComponent implements OnInit {
  brandItemSummaryList: BrandDto[];

  constructor(private productService: ProductService) { }

  ngOnInit() {
    this.getBrandItemSummary();
  }

  getBrandItemSummary(){
    this.productService.getBrandItemSummary("BrandsWithAssociatedProductCount")
      .subscribe(
        (data: BrandDto[]) => this.brandItemSummaryList = data,
        (err: any) => console.log(err)
      )
  }
}
