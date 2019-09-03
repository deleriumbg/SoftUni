import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import MovieDetails from 'src/models/Movie-Details';
import { MovieService } from '../movie.service';

@Injectable()
export class SingleMovieResolver implements Resolve<MovieDetails> {

    constructor(private movieService: MovieService) {}

    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        const id = route.params['id'];
        return this.movieService.getMovieById(id);
    }
}