const mongoose = require('mongoose');
const connectionString = 'mongodb://localhost:27017/mongo-db-playground';

module.exports = () => {
    mongoose.connect(connectionString);
}