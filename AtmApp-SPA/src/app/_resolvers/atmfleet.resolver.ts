import { Injectable } from "@angular/core";
import { AtmFleet } from "../_models/AtmFleet";
import { Resolve, Router, ActivatedRoute, ActivatedRouteSnapshot } from "@angular/router";
import { AtmfleetService } from "../_services/atmfleet.service";
import { AlertifyService } from "../_services/alertify.service";
import { Observable, of } from "rxjs";
import { catchError } from "rxjs/operators";

@Injectable()
export class AtmFleetResolver implements Resolve<AtmFleet> {
    constructor(private atmFleetService: AtmfleetService, private router: Router, private alertify: AlertifyService) {}

    resolve(route:ActivatedRouteSnapshot): Observable<AtmFleet> {
        return this.atmFleetService.getAtm(route.params['id']).pipe(
            catchError(error => {
                this.alertify.error('Problem retrieving data');
                this.router.navigate(['/atm-fleet']);
                return of(null);
            })
        );
    }
}