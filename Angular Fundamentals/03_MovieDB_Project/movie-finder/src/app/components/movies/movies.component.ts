import { Component, OnInit } from '@angular/core';
import Movie from 'src/models/Movie';
import { ActivatedRoute } from '@angular/router';

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

  constructor(
    private route: ActivatedRoute) { }

  ngOnInit() {
    const [ popular, inTheaters, popularKids, bestDrama ] = this.route.snapshot.data['movies'];
    this.popularMovies = popular;
    this.inTheaterMovies = inTheaters;
    this.popularKidsMovies = popularKids;
    this.bestDramaMovies = bestDrama;

    // this.movieService.getPopular().subscribe(data => {
    //   this.popularMovies = data;
    // });

    // this.movieService.getInTheaters().subscribe(data => {
    //   this.inTheaterMovies = data;
    // });

    // this.movieService.getPopularKids().subscribe(data => {
    //   this.popularKidsMovies = data;
    // });

    // this.movieService.getBestDrama().subscribe(data => {
    //   this.bestDramaMovies = data;
    // });
  }
}
