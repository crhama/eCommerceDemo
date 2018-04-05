import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { map } from 'rxjs/operators';

import { KeyValue } from '../../entities/key-value';
import { TableData } from '../../entities/table-data';

@Injectable()
export class MaintenanceService {
  baseUrl: string = "https://localhost:44322/api/";

  constructor(private http: HttpClient) { }

  getTableData(ename: string): Observable<TableData> {
    let url = this.constructUrl(ename);
    return this.http.get<KeyValue[][]>(url)
      .pipe(
        map(data => <TableData>{
          headerData: data[0], 
          bodyData: data.slice(1)
        })
      )
  }
  
  constructUrl(ename: string): string{
      let url = this.baseUrl;
    switch (ename) {
      case 'brand':
          url += 'brands/BrandMaintenanceTable';
        break;
      case 'product':
        url += 'products/ProductMaintenanceTable';
      break;      
      default:
        break;
    }
    return url;
  }
}
