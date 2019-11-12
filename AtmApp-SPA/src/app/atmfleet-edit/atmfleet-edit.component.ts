import { Component, OnInit } from '@angular/core';
import { AtmFleet } from '../_models/AtmFleet';
import { AtmfleetService } from '../_services/atmfleet.service';
import { AlertifyService } from '../_services/alertify.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-atmfleet-edit',
  templateUrl: './atmfleet-edit.component.html',
  styleUrls: ['./atmfleet-edit.component.css']
})
export class AtmfleetEditComponent implements OnInit {
  atmFleet: AtmFleet;

  constructor(private atmfleetService: AtmfleetService, private alertify: AlertifyService, 
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.loadAtm();
  }

  loadAtm() {
    this.atmfleetService.getAtm(+this.route.snapshot.params['id']).subscribe((atmFleet: AtmFleet) =>{
      this.atmFleet = atmFleet;
    }, error => {
      this.alertify.error(error);
    });

  }

}
