import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  private baseUrl: string = 'https://localhost:5000/api';

  constructor(private https: HttpClient) {}

  getGreeting(): Observable<any> {
    return this.https.get(`${this.baseUrl}/message/greet`);
  }
}
