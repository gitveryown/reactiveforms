import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  public baseUrl = 'https://localhost:5000/api/form';

  constructor(private http: HttpClient) {}

  sendFormData(data: any): Observable<any> {
    return this.http.post(this.baseUrl, data);
  }
}
