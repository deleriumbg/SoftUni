const fs = require('fs');
let Image = require('mongoose').model('Image');

module.exports = (req, res) => {
  if (req.pathname === '/search') {
    fs.readFile('./views/results.html', (err, data) => {

      if (err) {
        console.log(err);
        return;
      }

      res.writeHead(200, {
        'Content-Type': 'text/html'
      });

      let result = '';

      Image
        .find({})
        .then(images => {
          for (let image of images) {
            result += `<fieldset>
                          <legend>${image.title}:</legend>
                          <img src="${image.url}"/>
                          <p>${image.description}</p>
                         <button onclick='location.href="/delete?id=${image._id}"'class='deleteBtn'>Delete</button>
                        </fieldset>`;
          }

          data = data.toString().replace("<div class='replaceMe'></div>", result);

          res.end(data);
        }).catch(err => {
          console.log(err);
        });
    });
  } else {
    return true
  }
}
