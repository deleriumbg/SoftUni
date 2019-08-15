const Article = require('../models/Article');

module.exports = {
    createGet: (req, res) => {
        res.render('article/create');
    },
    createPost: (req, res) => {
        let { title, content } = req.body;
        let author = req.user._id;
        let user = req.user;

        let article = new Article({
            title,
            content,
            author
        });
        
        article
            .save()
            .then((result) => {
                user.articles.push(result._id);
                return user.save();
            })
            .then(() => {
                res.redirect('/');
            })
            .catch(console.error);
    },
    details: (req, res) => {
        let articleId = req.params.id;

        Article
            .findById(articleId)
            .populate('author')
            .then((article) => {
                let isAuthor = false;
                if (req.user) {
                    isAuthor = req.user.isAuthor(article) || req.user.isInRole('Admin');
                }
                
                res.render('article/details', { article, isAuthor });
            })
            .catch(console.error);
    },
    editGet: (req, res) => {
        const articleId = req.params.id;

        Article
            .findById(articleId)
            .then((article) => {
                res.render('article/edit', article);
            })
            .catch(console.error);
    },
    editPost: async (req, res) => {
        const articleId = req.params.id;
        const body = req.body;

        if (req.user.roles.indexOf('Admin') === -1 &&
            req.user.articles.indexOf(articleId) === -1) {
            res.redirect('/');
            return;
        }

        try {
            const article = await Article.findById(articleId);
            article.title = body.title;
            article.content = body.content;
            await article.save();
            res.redirect(`/article/details/${articleId}`);
        } catch (err) {
            body.error = err.message;
            body._id = articleId;
            res.render('article/edit', body);
        }
    },
    deleteGet: (req, res) => {
        const articleId = req.params.id;

        Article
            .findById(articleId)
            .then((article) => {
                res.render('article/delete', article);
            })
            .catch(console.error);
    },
    deletePost: async (req, res) => {
        const articleId = req.params.id;

        if (req.user.roles.indexOf('Admin') === -1 &&
            req.user.articles.indexOf(articleId) === -1) {
            res.redirect('/');
            return;
        }

        try {
            let article = await Article.findById(articleId)
                .populate('author');

            let author = article.author;
            const index = author.articles.indexOf(articleId);
            if (index === -1) {
                throw new Error('Article not found');
            }

            author.articles.splice(index, 1);
            await author.save();
            await Article.findByIdAndRemove(articleId);
            res.redirect('/');
        } catch (err) {
            console.error(err);
            res.redirect('/');
        }
    },
}