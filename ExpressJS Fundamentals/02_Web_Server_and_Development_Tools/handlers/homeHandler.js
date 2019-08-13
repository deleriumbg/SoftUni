const fs = require('fs');

module.exports = (req, res) => {
    if (req.path === '/' && req.method === 'GET') {
        fs.readFile('./views/home.html', (err, data) => {
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
    } else {
        return true;
    }
}