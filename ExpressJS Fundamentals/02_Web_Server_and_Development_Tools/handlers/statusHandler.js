const db = require('../config/dataBase');
const fs = require('fs');

module.exports = (req, res) => {
    if (req.path === '/status' && req.method === 'GET') {
        fs.readFile('./views/status.html', (err, data) => {
            if (err) {
                console.error(err);
                return;
            }
    
            res.writeHead(200, {
                'content-type': 'text/html'
            });
            res.write(data.toString().replace('{{replaceMe}}', `Total number of movies currently in the database: ${db.length}`));
            res.end();
        });
    } else {
        return true;
    }
}