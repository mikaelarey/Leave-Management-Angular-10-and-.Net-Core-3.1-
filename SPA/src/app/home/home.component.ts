import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  result: any = {};

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http.get('http://localhost:5000/user').subscribe(
      response => {
        this.result = response;
      }, error => {
        console.log('Unable to get response');
      });
  }
}
