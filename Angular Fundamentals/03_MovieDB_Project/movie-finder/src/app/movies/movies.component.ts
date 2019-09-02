import { Component, OnInit } from '@angular/core';
import { MovieService } from '../services/movie.service';
import Movie from 'src/models/Movie';

@Component({
  selector: 'app-movies',
  templateUrl: './movies.component.html',
  styleUrls: ['./movies.component.css']
})
export class MoviesComponent implements OnInit {
  popularMovies: Movie[];
  inTheaterMovies: Movie[];
  singleMovie: Movie;
  message = null;

  constructor(private movieService: MovieService) { }

  ngOnInit() {
    this.movieService.getPopular().subscribe(data => {
      this.popularMovies = data['results'].slice(0, 6);
      this.singleMovie = this.popularMovies[0];
    });

    this.movieService.getInTheaters().subscribe(data => {
      this.inTheaterMovies = data['results'].slice(0, 6);
    });
  }

  fromChild(event) {
    console.log(event);
    this.message = event;
  }
}
