const Cube = require('../models/Cube');

function handleQueryErrors(from, to) {
    let errors = [];

    if (!from || !to) {
        errors.push('Please fill all difficulties!');
    }
    if (from < 1 || from > 6) {
        errors.push('From must be between 1 and 6');
    }
    if (to < 1 || to > 6) {
        errors.push('To must be between 1 and 6');
    }
    if (from > to) {
        errors.push('From must be less than to');
    }
    
    return errors;
}

module.exports = {
    homeGet: (req, res) => {
        Cube
            .find()
            .sort('-difficulty')
            .then((cubes) => {
                res.render('index', { cubes });
            })
            .catch((err) => console.error(err));
    },
    about: (req, res) => {
        res.render('about');
    },
    search: (req, res) => {
        let { search, from, to } = req.query;
        from = Number(from);
        to = Number(to);

        let errors = handleQueryErrors(from, to);
        if (errors.length > 0) {
            res.locals.globalErrors = errors;
        }

        if (search && from === 0 && to === 0) {
            Cube.find({ 'name': new RegExp(search, 'i') })
                .then((cubes) => {
                    const filtered = cubes.filter(c => c.name.toLowerCase().includes(search.toLowerCase()));
                    res.render('index', { cubes: filtered });
            });
        } 
        if (search && from && to) {
            Cube.find({ 'name': new RegExp(search, 'i') })
                .then((cubes) => {
                    const filtered = cubes.filter(c => c.name.toLowerCase().includes(search.toLowerCase()));
                    res.render('index', { cubes: filtered });
            });
        }
    }
}