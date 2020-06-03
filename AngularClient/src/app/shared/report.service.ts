import { environment } from './../../environments/environment';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Job } from './../Models/job.model';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ReportService {

constructor( private http: HttpClient) { }


  getReportCusTomer() {
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };
    return this.http.get(environment.apiBaseURL + '/export/listCustomer');
  }
  getReportJobList() {
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };
    return this.http.get(environment.apiBaseURL + '/export/JobList');
  }

  getReportCusTomerByJob(job_id: number) {
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };
    // const url = `${environment.apiBaseURL}/export/${job_id}`;
    return this.http.get(environment.apiBaseURL + '/export/'+ job_id);
}
}
