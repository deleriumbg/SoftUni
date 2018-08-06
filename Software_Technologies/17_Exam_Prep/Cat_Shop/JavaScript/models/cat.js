const Sequelize = require('sequelize');

module.exports = function (sequelize) {
    let Cat = sequelize.define("Cat",{
        name:{
            type: Sequelize.TEXT,
            allowNull: false,
        },
        nickname:{
            type: Sequelize.TEXT,
            allowNull: false,
        },
        price:{
            type: Sequelize.DOUBLE,
            allowNull: false,
        }
    },{
        timestamps:false
    });

    return Cat;
};