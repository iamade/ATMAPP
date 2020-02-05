import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { AtmFleet } from '../_models/AtmFleet';

// const httpOptions = {
//   headers: new HttpHeaders({
//     'Authorization': 'Bearer ' + localStorage.getItem('token')
//   })
// };
@Injectable({
  providedIn: 'root'
})
export class AtmfleetService {
  baseUrl = environment.apiUrl;
  
constructor(private http: HttpClient) { }

getAtms(): Observable<AtmFleet[]> {
  return this.http.get<AtmFleet[]>(this.baseUrl + 'atmfleet/' + 'GetAtms'  );
}

getAtm(id): Observable<AtmFleet> {
  return this.http.get<AtmFleet>(this.baseUrl + 'atmfleet/' + 'GetAtm/' + id);
}

createAtm(resource: AtmFleet): Observable<AtmFleet> {
  return this.http.post<AtmFleet>(this.baseUrl + 'atmfleet/' + 'create',  resource);

}

updateAtm(id: number, atm: AtmFleet) {
  return this.http.put(this.baseUrl + 'atmfleet/' + 'update/' + id, atm);
}

deleteAtm(id): Observable<AtmFleet> {
  return this.http.delete<AtmFleet>(this.baseUrl + 'atmfleet/' + 'delete/' + id);

}

}
