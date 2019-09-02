import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import Movie from 'src/models/Movie';

const BASE_URL = 'https://api.themoviedb.org/3/';
const API_KEY = '&api_key=e5b3c5c2fd82aa307625969014a3e511';

@Injectable({
  providedIn: 'root'
})
export class MovieService {
  popularMoviesEndpoint = 'discover/movie?sort_by=popularity.desc';
  inTheatersMoviesEndpoint = 'discover/movie?primary_release_date.gte=2019-08-20';

  constructor(private http: HttpClient) { }

  getPopular() {
    return this.http.get<Movie[]>(BASE_URL + this.popularMoviesEndpoint + API_KEY);
  }

  getInTheaters() {
    return this.http.get<Movie[]>(BASE_URL + this.inTheatersMoviesEndpoint + API_KEY);
  }
}
