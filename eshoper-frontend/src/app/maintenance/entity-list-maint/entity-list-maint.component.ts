import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router'
import { KeyValue } from '../../entities/key-value';
import { MaintenanceService } from '../../data-service/maintenance/maintenance.service';
import { TableData } from '../../entities/table-data';

@Component({
  selector: 'app-entity-list-maint',
  templateUrl: './entity-list-maint.component.html',
  styleUrls: ['./entity-list-maint.component.css']
})
export class EntityListMaintComponent implements OnInit {
  tableData: TableData;
  ename: string;

  constructor(private maintService: MaintenanceService,
              private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.params
      .subscribe(
        params => {
          this.ename = params['ename'];
          this.getTableData(this.ename);
        }
      );    
  }

  getTableData(ename: string){
    this.maintService.getTableData(ename)
      .subscribe(
        (data: TableData) => this.tableData = data,
        (err: any) => console.log(err)
      );  
  }
}
