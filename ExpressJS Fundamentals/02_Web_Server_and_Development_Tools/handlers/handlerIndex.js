const homeHandler = require('./homeHandler');
const movieHandler = require('./movieHandler');
const statusHandler = require('./statusHandler');
const staticHandler = require('./staticFileHandler');

module.exports = [
    homeHandler,
    movieHandler,
    statusHandler,
    staticHandler
];