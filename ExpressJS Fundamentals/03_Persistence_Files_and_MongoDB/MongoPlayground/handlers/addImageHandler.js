const formidable = require('formidable');
const url = require('url');
const Image = require('mongoose').model('Image');

module.exports = (req, res) => {
  if (req.pathname === '/addImage' && req.method === 'POST') {
    addImage(req, res)
  } else if (req.pathname === '/delete' && req.method === 'GET') {
    deleteImg(req, res)
  } else {
    return true
  }
}

function addImage(req, res) {
  let form = new formidable.IncomingForm();

    form.parse(req, function (err, fields, files) {
      if (err) {
        console.log(err);
        return;
      }

      res.writeHead(200, {
        'Content-Type': 'text/plain'
      });
      debugger;
      let tags = fields.tagsId.split(',').reduce((accumulator, currentValue) => {
        if (accumulator.includes(currentValue) || currentValue.length === 0) {
          return accumulator;
        } else {
          accumulator.push(currentValue);
          return accumulator;
        }
      }, []);

      Image.create({
          url: fields.imageUrl,
          title: fields.imageTitle,
          description: fields.description,
          tags
        }).then(image => {
          res.writeHead(302, {
            location: '/'
          });
          res.end();
        }).catch(() => {
          res.writeHead(500, {
            'Content-Type':'text/plain'
          });
          res.write('500 Server Error');
          res.end();
        });
    });
}

function deleteImg(req, res) {
  let urlParts = url.parse(req.url, true);
  let id = urlParts.query.id

  Image.findByIdAndDelete(id)
  .then(() => {
    res.writeHead(302, {
      location: '/'
    });
    res.end();
  })
  .catch((err) => {
    console.log(err.errors);
  });
}
