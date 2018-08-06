const Sequelize = require('sequelize');

module.exports = function (sequelize) {
    let Task = sequelize.define("Task", {
        title: Sequelize.TEXT,
        status: {
            type:Sequelize.ENUM,
            values:["Open", 'In Progress', 'Finished']
        }
    }, {
        timestamps: false
    });

    return Task;
};