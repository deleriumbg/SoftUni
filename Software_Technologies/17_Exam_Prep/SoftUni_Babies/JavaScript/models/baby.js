const Sequelize = require('sequelize');

module.exports = function (sequelize) {
    let Baby = sequelize.define('Baby', {
        name:{
            type: Sequelize.STRING,
            allowNull: false,
        },
        gender:{
            type: Sequelize.STRING,
            allowNull: false,
        },
        birthday:{
            type: Sequelize.DATEONLY,
            allowNull: false,
        }
    },{
        timestamps: false,
    });

    return Baby;
};