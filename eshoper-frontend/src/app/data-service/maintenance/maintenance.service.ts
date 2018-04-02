import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { map } from 'rxjs/operators';

import { KeyValue } from '../../entities/key-value';
import { TableData } from '../../entities/table-data';

@Injectable()
export class MaintenanceService {

  constructor(private http: HttpClient) { }

  getTableData(): Observable<TableData> {
    return this.http.get<KeyValue[][]>('https://localhost:44322/api/products/ProductMaintenanceTable')
      .pipe(
        map(data => <TableData>{
          headerData: data[0], 
          bodyData: data.slice(1)
        })
      )
  }
  

}
