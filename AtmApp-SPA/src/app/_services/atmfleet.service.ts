import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { AtmFleet } from '../_models/AtmFleet';

@Injectable({
  providedIn: 'root'
})
export class AtmfleetService {
  baseUrl = environment.apiUrl;
  
constructor(private http: HttpClient) { }

getAtms(): Observable<AtmFleet[]> {
  return this.http.get<AtmFleet[]>(this.baseUrl + 'Getatms');
}

getAtm(id): Observable<AtmFleet> {
  return this.http.get<AtmFleet>(this.baseUrl + 'Getatm/' + id);
}

}
