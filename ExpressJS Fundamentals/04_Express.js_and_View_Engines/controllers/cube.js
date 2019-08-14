const Cube = require('../models/Cube');

function handleErrors(err,res,cubeBody) {
    let errors = [];

    for (let property in err.errors) {
        errors.push(err.errors[property].message);
    }

    res.locals.globalErrors = errors;
    res.render('create', cubeBody);
}

module.exports = {
    createGet:(req, res) => {
        res.render('create');
    },
    createPost:(req, res) => {
        const cubeBody = req.body;
        cubeBody.difficulty = Number(cubeBody.difficulty);

        console.log(cubeBody);
        Cube
            .create(cubeBody)
            .then((cube) => {
                res.redirect('/');
            })
            .catch(err => {
                handleErrors(err, res, cubeBody)
            })
    },
    details:(req, res) => {
        const cubeId = req.params.cubeId;
        Cube
            .findById(cubeId)
            .then((cube) => {
                res.render('details', cube);
            })
            .catch((err) => console.error(err));
    }
}