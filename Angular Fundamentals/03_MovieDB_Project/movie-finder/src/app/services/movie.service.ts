import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { map } from 'rxjs/operators'
import Movie from 'src/models/Movie';
import MovieDetails from 'src/models/Movie-Details';

const BASE_URL = 'https://api.themoviedb.org/3/';
const API_KEY = '&api_key=e5b3c5c2fd82aa307625969014a3e511';
const API_KEY_ALT = '?api_key=e5b3c5c2fd82aa307625969014a3e511';
const POPULAR = 'discover/movie?sort_by=popularity.desc';
const IN_THEATER = 'discover/movie?primary_release_date.gte=2019-08-20';
const KIDS = 'discover/movie?certification_country=US&certification.lte=G&sort_by=popularity.desc';
const BEST_DRAMA = 'discover/movie?with_genres=18&primary_release_year=2019';

@Injectable({
  providedIn: 'root'
})
export class MovieService {
  constructor(private http: HttpClient) { }

  getPopular() {
    return this.http.get<Movie[]>(BASE_URL + POPULAR + API_KEY)
      .pipe(map((data) => data['results'].slice(0, 6))
    );
  }

  getInTheaters() {
    return this.http.get<Movie[]>(BASE_URL + IN_THEATER + API_KEY)
      .pipe(map((data) => data['results'].slice(0, 6))
    );
  }

  getPopularKids() {
    return this.http.get<Movie[]>(BASE_URL + KIDS + API_KEY)
      .pipe(map((data) => data['results'].slice(0, 6))
    );
  }

  getBestDrama() {
    return this.http.get<Movie[]>(BASE_URL + BEST_DRAMA + API_KEY)
      .pipe(map((data) => data['results'].slice(0, 6))
    );
  }

  getMovieById(id: string) {
    return this.http.get<MovieDetails>(BASE_URL + `movie/${id}` + API_KEY_ALT);
  }

  searchMovie(query: string) {
    return this.http.get<Movie[]>(BASE_URL + `search/movie` + API_KEY_ALT + `&query=${query}`);
  }
}
