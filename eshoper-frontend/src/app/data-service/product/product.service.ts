import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { ProductDto } from '../../entities/productDto';
import { Observable } from 'rxjs/Observable';
import { CategoryDto } from '../../entities/categoryDto';
import { BrandDto } from '../../entities/brandDto';
import { HomeProductSliderVo } from '../../entities/home-product-sliderVo';
import { KeyValue } from '../../entities/key-value';
import { CategoryTabWithProductsViewModel } from '../../entities/Category-tab-Products-vm';

@Injectable()
export class ProductService {  
  readonly productBaseUrl = "https://localhost:44322/api/products/";
  readonly categoryBaseUrl = "https://localhost:44322/api/categories/";
  readonly brandBaseUrl = "https://localhost:44322/api/brands/";

  constructor(private http: HttpClient) { }

  getHomeProductSliders(reqUrl: string): Observable<HomeProductSliderVo[]>{
    return this.http.get<HomeProductSliderVo[]>(this.productBaseUrl + reqUrl);
  }

  getComponentProductItems(reqUrl: string): Observable<ProductDto[]>{    
    return this.http
      .get<ProductDto[]>(this.productBaseUrl + reqUrl);
  }

  getRecommendedItems(): Observable<ProductDto[][]> {
    let reqUrl = "RecommendedItems";
    return this.http
      .get<ProductDto[][]>(this.productBaseUrl + reqUrl);
  }

  getCategoryItems(reqUrl: string): Observable<CategoryDto[]>{
    return this.http
      .get<CategoryDto[]>(this.categoryBaseUrl + reqUrl);
  }

  getBrandItemSummary(reqUrl: string): Observable<BrandDto[]>{
    return this.http
      .get<BrandDto[]>(this.brandBaseUrl + reqUrl)
  }

  getCategoriesForTabDisplay(): Observable<CategoryTabWithProductsViewModel>{
    let reqUrl = "CategoriesForTabDisplay";
    return this.http
      .get<CategoryTabWithProductsViewModel>(this.categoryBaseUrl + reqUrl)
  }

  getTabProductsByCategory(cat: string): Observable<ProductDto[]>{
    let reqUrl = "TabProductsByCategory/" + cat;
    return this.http
      .get<ProductDto[]>(this.categoryBaseUrl + reqUrl);
  }

  getProductByCategory(reqUrl: string): Observable<ProductDto[]>{
    return this.http
      .get<ProductDto[]>(this.categoryBaseUrl + reqUrl);
  }

}
