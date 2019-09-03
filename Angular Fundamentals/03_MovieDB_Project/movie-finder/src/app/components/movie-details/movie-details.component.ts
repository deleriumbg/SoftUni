import { Component, OnInit } from '@angular/core';
import { MovieService } from '../../services/movie.service';
import { ActivatedRoute, Params } from '@angular/router';
import MovieDetails from 'src/models/Movie-Details';

@Component({
  selector: 'app-movie-details',
  templateUrl: './movie-details.component.html',
  styleUrls: ['./movie-details.component.css']
})
export class MovieDetailsComponent implements OnInit {
  id: string;
  movie: MovieDetails;
  movieGenres: string;

  constructor(
    private movieService: MovieService,
    private route: ActivatedRoute
    ) { }

  ngOnInit() {
    this.movie = this.route.snapshot.data['singleMovie'];
    this.movieGenres = this.movie.genres
      .map(el => el['name'])
      .join(', ');

    // implementation without resolver
    // this.id = this.route.snapshot.params['id'];

    // another approach used if the param (in this case: id) will change dynamically
    // this.route.params
    //   .subscribe((params: Params) => {
    //     this.id = params['id'];
    //   });

    // implementation without resolver
    // this.movieService.getMovieById(this.id)
    //   .subscribe((data) => {
    //     this.movie = data;
    //     this.movieGenres = this.movie.genres
    //       .map(el => el['name'])
    //       .join(', ')
    //   });
  }
}
