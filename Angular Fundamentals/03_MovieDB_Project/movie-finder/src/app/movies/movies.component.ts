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
  popularKidsMovies: Movie[];
  bestDramaMovies: Movie[];

  constructor(private movieService: MovieService) { }

  ngOnInit() {
    this.movieService.getPopular().subscribe(data => {
      this.popularMovies = data;
    });

    this.movieService.getInTheaters().subscribe(data => {
      this.inTheaterMovies = data;
    });

    this.movieService.getPopularKids().subscribe(data => {
      this.popularKidsMovies = data;
    });

    this.movieService.getBestDrama().subscribe(data => {
      this.bestDramaMovies = data;
    });
  }
}
