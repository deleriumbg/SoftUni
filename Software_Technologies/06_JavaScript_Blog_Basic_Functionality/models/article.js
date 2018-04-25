const Sequelize = require('sequelize');

module.exports = function(sequelize){
    const Article = sequelize.define('Article', {
        title: {
            type: Sequelize.STRING,
            allowNull: false,
            required: true
        },
        content: {
            type: Sequelize.STRING,
            allowNull: false,
            required: true
        },
        date: {
            type: Sequelize.STRING,
            required: true,
            defaultValue: sequelize.NOW
        },
    });

    Article.associate = function (models){
        Article.belongsTo(models.User, {
            foreignKey:'authorId',
            targetKey:'id'
        });
    };
    return Article;
};