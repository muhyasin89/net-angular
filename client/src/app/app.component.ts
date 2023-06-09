import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import {NgbConfig} from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent  implements OnInit{

  constructor(private http:HttpClient, ngbConfig: NgbConfig){
    ngbConfig.animation = false;
  }
  
  title = 'client';

  users: any;

  ngOnInit(): void{
    this.http.get('http://localhost:5021/api/user').subscribe({
      next: response => this.users = response,
      error : error => console.log(error),
      complete: () => {
        
      }
    }
      
    );
  }
}
