const auth = require('../config/auth');
const controllers = require('../controllers/index');

module.exports = (app) => {
    app.get('/', controllers.homeController.index);

    // User routes
    app.get('/user/register', auth.isAnonymous, controllers.userController.registerGet);
    app.post('/user/register', auth.isAnonymous, controllers.userController.registerPost);
    app.get('/user/login', auth.isAnonymous, controllers.userController.loginGet);
    app.post('/user/login', auth.isAnonymous, controllers.userController.loginPost);
    app.get('/user/details', auth.isAuthed, controllers.userController.details);
    app.get('/user/logout', auth.isAuthed, controllers.userController.logout);

    // Article routes
    app.get('/article/create', auth.isAuthed, controllers.articleController.createGet);
    app.post('/article/create', auth.isAuthed, controllers.articleController.createPost);
    app.get('/article/details/:id', controllers.articleController.details);
    app.get('/article/edit/:id', controllers.articleController.editGet);
    app.post('/article/edit/:id', controllers.articleController.editPost);
    app.get('/article/delete/:id', controllers.articleController.deleteGet);
    app.post('/article/delete/:id', controllers.articleController.deletePost);
};

