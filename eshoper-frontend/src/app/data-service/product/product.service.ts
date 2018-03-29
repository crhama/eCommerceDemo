import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { ProductVo } from '../../entities/productvo';
import { Observable } from 'rxjs/Observable';
import { CategoryDto } from '../../entities/categoryDto';
import { BrandItemSummaryVo } from '../../entities/brand-item-summaryVo';
import { HomeProductSliderVo } from '../../entities/home-product-sliderVo';

@Injectable()
export class ProductService {  
  readonly productBaseUrl = "https://localhost:44322/api/productsapi/";
  readonly categoryBaseUrl = "https://localhost:44322/api/categoriesapi/";
  readonly brandBaseUrl = "https://localhost:44322/api/brands/";

  constructor(private http: HttpClient) { }

  getHomeProductSliders(reqUrl: string): Observable<HomeProductSliderVo[]>{
    return this.http.get<HomeProductSliderVo[]>(this.productBaseUrl + reqUrl);
  }

  getComponentProductItems(reqUrl: string): Observable<ProductVo[]>{    
    return this.http
      .get<ProductVo[]>(this.productBaseUrl + reqUrl);
  }

  getRecommendedItems(reqUrl: string): Observable<ProductVo[][]> {
    return this.http
      .get<ProductVo[][]>(this.productBaseUrl + reqUrl);
  }

  getCategoryItems(reqUrl: string): Observable<CategoryDto[]>{
    return this.http
      .get<CategoryDto[]>(this.categoryBaseUrl + reqUrl);
  }

  getBrandItemSummary(reqUrl: string): Observable<BrandItemSummaryVo[]>{
    return this.http
      .get<BrandItemSummaryVo[]>(this.brandBaseUrl + reqUrl)
  }

  getProductByCategory(reqUrl: string): Observable<ProductVo[]>{
    return this.http
      .get<ProductVo[]>(this.categoryBaseUrl + reqUrl);
  }

}
