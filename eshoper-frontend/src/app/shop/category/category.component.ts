import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../data-service/product/product.service';
import { CategoryDto } from '../../entities/categoryDto';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {
  categoryItemList: CategoryDto[];

  constructor(private productService: ProductService) { }

  ngOnInit() {
    this.getCategoryItems();
  }

  getCategoryItems(): void{
    this.productService.getCategoryItems("CategoriesForExistingProducts")
      .subscribe(
        (data: CategoryDto[]) => this.categoryItemList = data,
        (err: any) => console.log(err)
      )
      
  }

}
