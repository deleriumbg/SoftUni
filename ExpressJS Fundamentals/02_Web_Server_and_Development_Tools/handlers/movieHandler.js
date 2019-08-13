const db = require('../config/dataBase');
const fs = require('fs');
let qs = require('querystring');

module.exports = (req, res) => {
    if (req.path === '/viewAllMovies' && req.method === 'GET') {
        fs.readFile('./views/viewAll.html', (err, data) => {
            if (err) {
                console.error(err);
                return;
            }
            
            let allMoviesHtml = '';
            for (const movie of db) {
                allMoviesHtml += `<div class="movie"><a href="/movies/details/${movie.id}"><img class="moviePoster" src="${movie.moviePoster}" /></a></div>`;
            }

            let responseHtml = data.toString().replace('<div id="replaceMe">{{replaceMe}}</div>', allMoviesHtml);
            res.writeHead(200, {
                'content-type': 'text/html'
            });
            res.write(responseHtml);
            res.end();
        });
    } else if (req.path === '/addMovie' && req.method === 'GET') {
        fs.readFile('./views/addMovie.html', (err, data) => {
            if (err) {
                console.error(err);
                return;
            }

            res.writeHead(200, {
                'content-type': 'text/html'
            });
            res.write(data);
            res.end();
        });
    } else if (req.path === '/addMovie' && req.method === 'POST') {
        let dataString = '';

        req.on('data', (data) => {
            dataString += data;
        });
        
        req.on('end', () => {
            let movie = qs.parse(dataString);

            if (movie.movieTitle === "" || movie.moviePoster === "") {
                fs.readFile('./views/addMovie.html', (err, data) => {
                    if (err) {
                        console.error(err);
                        return;
                    }
        
                    res.writeHead(200, {
                        'content-type': 'text/html'
                    });
                    res.write(data.toString().replace('<div id="replaceMe">{{replaceMe}}</div>','<div id="errBox"><h2 id="errMsg">Please fill all fields</h2></div>'));
                    res.end();
                });
            } else {
                fs.readFile('./views/addMovie.html', (err, data) => {
                    if (err) {
                        console.error(err);
                        return;
                    }
        
                    res.writeHead(200, {
                        'content-type': 'text/html'
                    });
                    res.write(data = data.toString().replace('<div id="replaceMe">{{replaceMe}}</div>','<div id="succssesBox"><h2 id="succssesMsg">Movie Added</h2></div>'));
                    res.end();
                });
            }

            db.push(movie);
            });
    } else if (req.path.startsWith('/movies/details') && req.method === 'GET') {
        let id = +req.path.split('/').pop();

        for (let movie of db) {
            if (id === movie.id) {
                fs.readFile('./views/details.html', (err, data) => {
                    if (err) {
                        console.log(err);
                        return;
                    }

                    let result = '';

                    result += 
                    `<div class="content">
                        <img src="${movie.moviePoster}> alt=""/>
                        <h3>Title ${movie.movieTitle}</h3>
                        <h3>Year ${movie.movieYear}</h3>
                        <p>${movie.movieDescription}</p>
                    </div>`;

                    res.writeHead(200, {
                        'Content-Type': 'text/html'
                    });
                    
                    res.write(data.toString().replace('<div id="replaceMe">{{replaceMe}}</div>', result));
                    res.end();
                });
            }
        }
    } else {
        return true;
    }
}