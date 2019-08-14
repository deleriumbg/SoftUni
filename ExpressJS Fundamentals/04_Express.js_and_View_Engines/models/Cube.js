const mongoose = require('mongoose');

const cubeSchema = new mongoose.Schema({
    name:{type: mongoose.SchemaTypes.String, required: true},
    description:{type: mongoose.SchemaTypes.String, required: true},
    imageUrl:{type: mongoose.SchemaTypes.String, required: true},
    difficulty:{type: mongoose.SchemaTypes.Number, required: true}
});

cubeSchema.path('name')
    .validate(function() {
        return this.name.length >= 3 && this.name.length <= 15;},
        'Name must be between 3 and 15 symbols!'
);

cubeSchema.path('description')
    .validate(function() {
        return this.description.length >= 20 && this.description.length <= 300;},
        'Description must be between 20 and 300 symbols'
);

cubeSchema.path('imageUrl')
    .validate(function() {
        return this.imageUrl.startsWith('https://') && (this.imageUrl.endsWith('.jpg') || this.imageUrl.endsWith('.png'));},
        'Image URL must start with https:// and must end with .jpg or .png'
);

cubeSchema.path('difficulty')
    .validate(function() {
        return this.difficulty >= 1 && this.difficulty <= 6;},
        'Difficulty must be between 1 and 6'
);

module.exports = mongoose.model('Cube', cubeSchema);