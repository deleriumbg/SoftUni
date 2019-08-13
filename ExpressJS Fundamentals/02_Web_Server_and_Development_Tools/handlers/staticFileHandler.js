const fs = require('fs');

function getContentType(url) {
    let contentType = 'text/plain';
    if (url.endsWith('.html')) {
        contentType = 'text/html';
    } else if (url.endsWith('.css')) {
        contentType = 'text/css';
    } else if (url.endsWith('.js')) {
        contentType = 'text/javascript';
    } else if (url.endsWith('.png')) {
        contentType = 'image/png';
    } else if (url.endsWith('.jpg') || url.endsWith('.jpeg')) {
        contentType = 'image/jpeg';
    }

    return contentType;
}

module.exports = (req, res) => {
    if (req.path.startsWith('/public') && req.method === 'GET') {
        fs.readFile(`./${req.path}`, (err, data) => {
            if (err) {
                res.writeHead(404);
                res.write('404 Not Found');
                res.end();
                return;
            }
    
            if (req.path.endsWith('.html') || req.path.endsWith('.css') || 
                req.path.endsWith('.js') || req.path.endsWith('.png') || 
                req.path.endsWith('.jpg') || req.path.endsWith('.jpeg')) {
                res.writeHead(200, {
                    'content-type': getContentType(req.path)
                });
                res.write(data);
                res.end();
            } else {
                res.writeHead(403);
                res.write('403 Forbidden');
                res.end();
            }
        });
    }
}
