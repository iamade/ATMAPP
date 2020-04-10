import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class FaultLogsService {
  baseUrl = environment.apiUrl;
constructor() { }

}
