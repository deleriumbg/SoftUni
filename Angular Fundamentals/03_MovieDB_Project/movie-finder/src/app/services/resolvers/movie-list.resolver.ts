import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { MovieService } from '../movie.service';
import { forkJoin } from 'rxjs';
import Movie from 'src/models/Movie';

@Injectable()
export class MovieListResolver implements Resolve<Movie[]> {

    constructor(private movieService: MovieService) {}

    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        return forkJoin(
            this.movieService.getPopular(),
            this.movieService.getInTheaters(),
            this.movieService.getPopularKids(),
            this.movieService.getBestDrama()
        )
    }
}