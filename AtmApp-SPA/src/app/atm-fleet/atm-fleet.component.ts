import { Component, OnInit, AfterViewInit } from '@angular/core';
declare const $;
@Component({
  selector: 'app-atm-fleet',
  templateUrl: './atm-fleet.component.html',
  styleUrls: ['./atm-fleet.component.css']
})
export class AtmFleetComponent implements OnInit {
  public atmfleet: any[];
  
  constructor() { }

  ngOnInit() {
    // tslint:disable-next-line: only-arrow-functions
    $(function() {
      $('#example').DataTable( {
        dom: 'Bfrtip',
        buttons: [
            'copy', 'csv', 'excel', 'pdf', 'print'
        ]
    } );
    });
  }

}
