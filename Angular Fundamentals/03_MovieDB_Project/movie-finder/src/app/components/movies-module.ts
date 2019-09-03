import { NgModule} from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';

import { MovieComponent } from './movie/movie.component';
import { MoviesComponent } from './movies/movies.component';
import { MovieDetailsComponent } from './movie-details/movie-details.component';
import { MovieSearchComponent } from './movie-search/movie-search.component';
import { MovieListResolver } from '../services/resolvers/movie-list.resolver';
import { SingleMovieResolver } from '../services/resolvers/single-movie.resolver';
import { MovieService } from '../services/movie.service';

@NgModule({
    declarations: [
        MovieComponent,
        MoviesComponent,
        MovieSearchComponent,
        MovieDetailsComponent
    ],
    imports: [
        CommonModule,
        RouterModule,
        FormsModule
    ],
    exports: [
        MoviesComponent
    ],
    providers: [
        MovieService,
        SingleMovieResolver, 
        MovieListResolver
    ]
})

export class AppMoviesModule{}