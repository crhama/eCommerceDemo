import { Component, OnInit } from '@angular/core';

import { KeyValue } from '../../entities/key-value';

@Component({
  selector: 'app-edit-maint',
  templateUrl: './edit-maint.component.html',
  styleUrls: ['./edit-maint.component.css']
})
export class EditMaintComponent implements OnInit {
  tableData: KeyValue[][];
  headerData: KeyValue[];
  bodyData: KeyValue[][];

  constructor() { }

  ngOnInit() {
    this.tableData =
    [
      [
        new KeyValue('id', 'id'), new KeyValue('BrandName', 'Brand')
      ],
      [
        new KeyValue('id', '1'), new KeyValue('BrandName', 'Anne Klein')
      ],
      [
        new KeyValue('id', '2'), new KeyValue('BrandName', 'Georgio Armani')
      ],
    ]

    this.headerData = this.tableData[0];
    this.bodyData = this.tableData.slice(1)
  }

}
