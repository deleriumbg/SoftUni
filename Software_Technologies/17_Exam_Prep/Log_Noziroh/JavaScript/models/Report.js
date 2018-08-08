const Sequelize = require('sequelize');

module.exports = function (sequelize) {
    let Report = sequelize.define('Report', {
        status:{
            type: Sequelize.TEXT,
            allowNull: false
        },

        message:{
            type: Sequelize.TEXT,
            allowNull: false
        },

        origin:{
            type: Sequelize.TEXT,
                allowNull: false
        }
    },{
        timestamps: false,
    });

    return Report;
};