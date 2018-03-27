import { Component, OnInit } from '@angular/core';
import { ProductService } from '../data-service/product/product.service';
import { HomeProductSliderVo } from '../entities/home-product-sliderVo';

@Component({
  selector: 'app-slider',
  templateUrl: './slider.component.html',
  styleUrls: ['./slider.component.css']
})
export class SliderComponent implements OnInit {

  constructor(private productService: ProductService) { }
  homeProductSliderList: HomeProductSliderVo[];
  ngOnInit() {
    this.getHomeProductSliders();
  }

  getHomeProductSliders(){
    this.productService.getHomeProductSliders("HomeProductSliders")
      .subscribe(
        (data: HomeProductSliderVo[]) => this.homeProductSliderList = data,
        (err: any) => console.log(err)
      )      
  }

}
