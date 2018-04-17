import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { ProductMaintenanceTableViewModel } from '../entities/pdct-maint-tbl';
import { ColumnViewModel } from '../entities/column-vm';

@Injectable()
export class MaintenanceService {
  private readonly productBaseUrl = "https://localhost:44322/api/products/";
  private readonly columnBaseUrl = "https://localhost:44322/api/Columns/";
  constructor(private http: HttpClient) { }

  getProductMaintenanceTable():   
              Observable<ProductMaintenanceTableViewModel>{
                let url = "ProductMaintenanceTable";
    return this.http.get<ProductMaintenanceTableViewModel>(
      this.productBaseUrl + url
    );
  }
5
  GetColumnsForDisplay():   
              Observable<ColumnViewModel[]>{
                let url = "ColumnsForDisplay";
    return this.http.get<ColumnViewModel[]>(
      this.columnBaseUrl + url
    );
  }

}
