const mongoose = require('mongoose');

const articleSchema = new mongoose.Schema ({
    title: { type: mongoose.Schema.Types.String, required: true },
    content: { type: mongoose.Schema.Types.String, required: true },
    author: { type: mongoose.Schema.Types.ObjectId, ref: 'User', required: true },
    date: { type: mongoose.Schema.Types.Date, default: Date.now }
});

module.exports = mongoose.model('Article', articleSchema);