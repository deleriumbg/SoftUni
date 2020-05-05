const Cat = require('../models').Cat;

module.exports = {
    index: (req, res) => {
        let cats = Cat.findAll().then(cats => {
            res.render('cat/index', {'cats':cats})
        });
    },

    createGet: (req, res) => {
        res.render('cat/create');
    },

    createPost: (req, res) => {
        let args = req.body.cat;

        Cat.create(args).then(()=>{
            res.redirect('/');
        })

    },

    editGet: (req, res) => {
        let id = req.params.id;
        Cat.findById(id).then(cats => {
            res.render('cat/edit', {'cat':cats})
        })
    },

    editPost: (req, res) => {
        let id = req.params.id;
        let args = req.body.cat;

        Cat.findById(id).then(cats => {
            cats.updateAttributes(args).then(() => {
                res.redirect('/');
            })
        })
    },

    deleteGet: (req, res) => {
        let id = req.params.id;
        Cat.findById(id).then(cats => {
            res.render('cat/delete', {'cat':cats})
        })
    },

    deletePost: (req, res) => {
        let id = req.params.id;

        Cat.findById(id).then(cats => {
            cats.destroy().then(() => {
                res.redirect('/');
            })
        })
    }
};
