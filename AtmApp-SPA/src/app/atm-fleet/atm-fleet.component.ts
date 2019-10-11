import { AtmfleetService } from './../_services/atmfleet.service';
import { Component, OnInit, AfterViewInit } from '@angular/core';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-atm-fleet',
  templateUrl: './atm-fleet.component.html',
  styleUrls: ['./atm-fleet.component.css']
})
export class AtmFleetComponent implements OnInit {
  public atmfleet: any[];
  dtOptions: any = {};
  dtTrigger: Subject<any> = new Subject();
  TableData: any = [];
  ShowEditTable: boolean = false;
  EditRowId: any = '';

  Edit(val) {
    this.EditRowId = val;
  }

  constructor(private atmfleetservices: AtmfleetService) { }

  ngOnInit() {
    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 30,
      dom: 'Bfrtip',
      buttons: [
        'print',
        'excel',
        'pdf',
        'csv',
      ]
    };

    this.atmfleetservices.getAtms().subscribe(
      result => {
        this.atmfleet = result;
        console.log(result);
        this.dtTrigger.next();

      },
      error => console.log(error)
    );
  }

}
