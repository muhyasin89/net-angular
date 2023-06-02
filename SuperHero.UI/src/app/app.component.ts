import { Component } from '@angular/core';
import { SuperHero } from './models/super-hero';
import { SuperHeroService } from './services/super-hero.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'SuperHero.UI';
  heroes: SuperHero[] = [];
  heroToEdit?: SuperHero;

  constructor(private superHeroService: SuperHeroService) {}

  ngOnInit() : void{
    this.superHeroService.getSuperHeros()
    .subscribe((result: SuperHero[]) => (this.heroes = result));
  }

  initNewHero(){
    this.heroToEdit =  new SuperHero()
  }

  updateHeroList(heroes: SuperHero[]){
    this.heroes = heroes
  }

  editHero(hero: SuperHero){
    this.heroToEdit = hero;
  }
}
