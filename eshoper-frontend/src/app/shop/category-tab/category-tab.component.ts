import { Component, OnInit } from '@angular/core';
import { ProductVo } from '../../entities/productvo';
import { ProductService } from '../../data-service/product/product.service';

@Component({
  selector: 'app-category-tab',
  templateUrl: './category-tab.component.html',
  styleUrls: ['./category-tab.component.css']
})
export class CategoryTabComponent implements OnInit {
  tshirtTabList: ProductVo[];
  blazersTabList: ProductVo[];
  sunglassTabList: ProductVo[];
  kidsTabList: ProductVo[];

  constructor(private productService: ProductService) { }

  ngOnInit() {
    this.getProductByCategory();
    this.blazersTabList = this.tshirtTabList;
    this.sunglassTabList = this.tshirtTabList;
    this.kidsTabList = this.tshirtTabList;
  }

  getProductByCategory(): void{
    this.productService.getProductByCategory("a84e5712-836a-4447-8ef9-cfaf25bd1465/products")
      .subscribe(
        (data: ProductVo[]) => this.tshirtTabList = data,
        (err: any) => console.log(err)
      )

    // this.tshirtTabList = [
    //   { 
    //     id: 'a84e5712-836a-4447-8ef9-cfaf25bd1465', productDescription: 'Easy Polo Black Edition', 
    //     promotionType: 1, price: 27.99, imageUrl: 'https://localhost:44380/images/products/home/gallery1.jpg'
    //   },
    //   { 
    //     id: 'a84e5712-836a-4447-8ef9-cfaf25bd1465', productDescription: 'Easy Polo Black Edition', 
    //     promotionType: 1, price: 14.99, imageUrl: 'https://localhost:44380/images/products/home/gallery2.jpg'
    //   },
    //   { 
    //     id: 'a84e5712-836a-4447-8ef9-cfaf25bd1465', productDescription: 'Easy Polo Black Edition', 
    //     promotionType: 1, price: 25.99, imageUrl: 'https://localhost:44380/images/products/home/gallery3.jpg'
    //   },
    //   { 
    //     id: 'a84e5712-836a-4447-8ef9-cfaf25bd1465', productDescription: 'Easy Polo Black Edition', 
    //     promotionType: 2, price: 33.99, imageUrl: 'https://localhost:44380/images/products/home/gallery4.jpg'
    //   }
    // ];
  }

}
