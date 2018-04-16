import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { ProductMaintenanceTableViewModel } from '../entities/pdct-maint-tbl';

@Injectable()
export class MaintenanceService {
  private readonly productBaseUrl = "https://localhost:44322/api/products/";
  constructor(private http: HttpClient) { }

  getProductMaintenanceTable():   
              Observable<ProductMaintenanceTableViewModel>{
                let url = "ProductMaintenanceTable";
    return this.http.get<ProductMaintenanceTableViewModel>(
      this.productBaseUrl + url
    );
  }

}
