import { Component, OnInit } from '@angular/core';
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

  constructor(private maintService: MaintenanceService) { }

  ngOnInit() {
    this.getTableData();
  }

  getTableData(){
    this.maintService.getTableData()
      .subscribe(
        (data: TableData) => this.tableData = data,
        (err: any) => console.log(err)
      );  
  }
}
