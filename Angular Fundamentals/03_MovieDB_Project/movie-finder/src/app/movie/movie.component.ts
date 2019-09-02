import { Component, OnInit, Input } from '@angular/core';
import Movie from 'src/models/Movie';

@Component({
  selector: 'app-movie',
  templateUrl: './movie.component.html',
  styleUrls: ['./movie.component.css']
})
export class MovieComponent implements OnInit {
  // this property value is bound to a different property name
  // when this component is instantiated in a template.
  @Input('movie') 
  movie: Movie;
  imagePath: string;

  constructor() { }

  ngOnInit() {
    this.imagePath = 'https://image.tmdb.org/t/p/w500' + this.movie.poster_path;
  }
}
