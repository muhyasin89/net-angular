import { Injectable } from '@angular/core';
import { SuperHero } from '../models/super-hero';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class SuperHeroService {
  url = "SuperHero";
  constructor(private http: HttpClient) { }
  public getSuperHeros():  Observable<SuperHero[]>{
    return this.http.get<SuperHero[]>(`${environment.apiUrl}/${this.url}`);
  }
}
