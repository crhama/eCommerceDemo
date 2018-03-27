import { Component, OnInit } from '@angular/core';
import { BrandItemSummaryVo } from '../../entities/brand-item-summaryVo';
import { ProductService } from '../../data-service/product/product.service';

@Component({
  selector: 'app-brand',
  templateUrl: './brand.component.html',
  styleUrls: ['./brand.component.css']
})
export class BrandComponent implements OnInit {
  brandItemSummaryList: BrandItemSummaryVo[];

  constructor(private productService: ProductService) { }

  ngOnInit() {
    this.getBrandItemSummary();
  }

  getBrandItemSummary(){
    this.productService.getBrandItemSummary("BrandItemSummary")
      .subscribe(
        (data: BrandItemSummaryVo[]) => this.brandItemSummaryList = data,
        (err: any) => console.log(err)
      )
  }
}
