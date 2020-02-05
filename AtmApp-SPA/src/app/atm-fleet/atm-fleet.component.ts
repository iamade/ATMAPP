import { AtmfleetService } from './../_services/atmfleet.service';
import { Component, OnInit, AfterViewInit } from '@angular/core';
import { Subject } from 'rxjs';
import { AuthService } from '../_services/auth.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AtmFleet } from '../_models/AtmFleet';
import { AlertsService } from 'angular-alert-module';
import { Router, ActivatedRoute } from '@angular/router';
import { AlertifyService } from '../_services/alertify.service';

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
  createNewAtm: AtmFleet;
  atmToUpdate: AtmFleet;
  deletedAtm: AtmFleet;

  Edit(val) {
    this.EditRowId = val;
  }

  constructor(private atmfleetservices: AtmfleetService, private route: ActivatedRoute, 
      private modalService: NgbModal,  private router: Router, private alertify: AlertifyService ) { }

  ngOnInit() {
    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 40,
      dom: 'Bfrtip',
      buttons: [
        'print',
        'excel',
        'pdf',
        'csv',
      ]
    };
   this.loadAtms();
   

    this.route.data.subscribe(data => {
      this.atmToUpdate = data['atm'];
    });
  }

  createModal(id: string) {
    this.modalService.open(id, {scrollable: true});

  }

  // createATM(body) {
  //   this.atmfleetservices.createAtm(body).subscribe( res => {

  //   });

  // }

  loadAtms() { 
    this.atmfleetservices.getAtms().subscribe(
      result => {
        this.atmfleet = result;
        //console.log(result);
        this.dtTrigger.next();

      },
      error => console.log(error)
    );
   }

  cancel() {
    this.modalService.dismissAll();
  }

  createAtm(body) {
      this.atmfleetservices.createAtm(body).subscribe((res: AtmFleet) => {
      this.createNewAtm = res;
      this.alertify.success('ATM created Successful');
      this.router.navigate(['/dashboard']);
      this.loadAtms();
    },
    err => {
      this.alertify.error('ATM creation failed');
    });

  }

  editAtmModal(id: string, atmId) {
    this.modalService.open(id, {scrollable: true});
    this.getAtmById(atmId);
  }

  getAtmById(id) {
    this.atmfleetservices.getAtm(id).subscribe((res: AtmFleet) => {
      this.atmToUpdate = res;
    });
  }

  updateApp(id, atm: AtmFleet) {
    this.atmfleetservices.updateAtm(id, atm).subscribe((res: AtmFleet) => {
      this.atmToUpdate = res;
      this.alertify.success('ATM updated Successfully');
      this.modalService.dismissAll();
      this.loadAtms();

      
    }, err => {
      this.alertify.error('ATM update failed');
    });
  }

  deleteAtm(id) {
    this.alertify.confirm('Are you sure you want to delete this ATM', () => {
      this.atmfleetservices.deleteAtm(id).subscribe((res: AtmFleet) => {
        this.deletedAtm = res;
        this.alertify.success('delete Successful');
        this.loadAtms();
      }, error => {
        this.alertify.error('Failed to delete the application');
      });
    });
  }
  

}
