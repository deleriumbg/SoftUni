const mongoose = require('mongoose');
mongoose.Promise = global.Promise;

module.exports = config => {
    mongoose.connect(config.dbPath, {
        useMongoClient: true
    });
    const db = mongoose.connection;
    db.once('open', err => {
        if (err) throw err;
    });
    db.on('error', reason => {
        console.log(reason);
    });
};