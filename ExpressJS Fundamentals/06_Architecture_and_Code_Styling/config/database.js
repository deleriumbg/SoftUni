const mongoose = require('mongoose');
const User = require('../models/User');
mongoose.Promise = global.Promise;

module.exports = (config) => {
    mongoose.connect(config.connectionString, {
        useMongoClient: true
    });

    let database = mongoose.connection;
    database.once('open', (err) => {
        if (err) {
            throw err;
        }
        User.seedAdmin().then(() => {
            console.log('Database ready!');
        }).catch((reason) => {
            console.log('Something went wrong');
            console.log(reason);
        });
    });
};