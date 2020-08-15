import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  baseUrl = 'http://localhost:5000/auth/';
  constructor(private http: HttpClient) { }

  // tslint:disable-next-line: typedef
  register(model: any) {
    return this.http.post(this.baseUrl + 'register', model);
  }

}
