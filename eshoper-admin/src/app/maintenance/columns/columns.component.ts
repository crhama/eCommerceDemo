import { Component, OnInit } from '@angular/core';
import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';
import { ColumnViewModel } from '../../entities/column-vm';
import { MaintenanceService } from '../maintenance.service';

@Component({
  selector: 'app-columns',
  templateUrl: './columns.component.html',
  styleUrls: ['./columns.component.css']
})
export class ColumnsComponent implements OnInit {
  columnListVM: ColumnViewModel[];
  closeResult: string;

  constructor(private modalService: NgbModal,
              private maintService: MaintenanceService) {}

  ngOnInit() {
    this.GetColumnsForDisplay();
  }

  GetColumnsForDisplay(){
    this.maintService.GetColumnsForDisplay()
        .subscribe(
          (data: ColumnViewModel[]) => this.columnListVM = data,
          (err: any) => console.log(err)
        )
  }

  open(content) {
    this.modalService.open(content).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });
  }

  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return  `with: ${reason}`;
    }
  }

}
