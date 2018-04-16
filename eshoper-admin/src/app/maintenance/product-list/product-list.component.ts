import { Component, OnInit } from '@angular/core';
import { MaintenanceService } from '../maintenance.service';
import { ProductViewModel } from '../../entities/product-vm';
import { PromotionType } from '../../entities/promotion-type';
import { KeyValue, KeyValueWidth } from '../../entities/key-value';
import { ProductMaintenanceTableViewModel } from '../../entities/pdct-maint-tbl';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  headerKV: KeyValueWidth[];
  bodyKV: KeyValue[][];
  constructor(private maintService: MaintenanceService) { }

  ngOnInit() {
    this.getProductMaintenanceTable();
  }

  getProductMaintenanceTable(){
    this.maintService.getProductMaintenanceTable()
          .subscribe(
            (data: ProductMaintenanceTableViewModel) =>{
              this.headerKV = data.headerKV;
              this.bodyKV = data.bodyKV;
            },
            (err: any) => console.log(err)
          );
  }

}
