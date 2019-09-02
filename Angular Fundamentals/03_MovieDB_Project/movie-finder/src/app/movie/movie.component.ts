import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
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

  @Output()
  viewDetailsButtonEmitter: EventEmitter<number> = new EventEmitter();

  constructor() { }

  ngOnInit() {
    this.imagePath = 'https://image.tmdb.org/t/p/w500' + this.movie.poster_path;
  }

  viewDetails() {
    console.log('button with id ' + this.movie.id + ' clicked');
    this.viewDetailsButtonEmitter.emit(this.movie.id)
  }
}
