const fs = require('fs');
let data = {};

module.exports = {
    put:(key, value) => {
        if (typeof(key) !== 'string'){
            throw new Error('The key should be a string');
        }
        if (data.hasOwnProperty(key)) {
            throw new Error('The key already exists');
        }
        data[key] = value;
    },
    get:(key) => {
        if (typeof(key) !== 'string'){
            throw new Error('The key should be a string');
        }
        if (!data.hasOwnProperty(key)) {
            throw new Error('The key does not exists');
        }
        return data[key];
    },
    getAll:() => {
        if (Object.keys(data).length === 0) {
            throw new Error('The storage is empty');
        }
        return data;
    },
    update:(key, newValue) => {
        if (typeof(key) !== 'string'){
            throw new Error('The key should be a string');
        }
        if (!data.hasOwnProperty(key)) {
            throw new Error('The key does not exists');
        }
        data[key] = newValue;
    },
    delete:(key) => {
        if (typeof(key) !== 'string'){
            throw new Error('The key should be a string');
        }
        if (!data.hasOwnProperty(key)) {
            throw new Error('The key does not exists');
        }
        delete data[key];
    },
    clear:() => {
        data = {};
    },
    save:() => {
        let dataJson = JSON.stringify(data);
        fs.writeFile('storage.json', dataJson, (err) => {
            if (err) {
                throw err;
            }
            console.log('The file has been saved!');
        });
    },
    load:() => {
        fs.readFile('storage.json', (err, dataJson) => {
            if (err) {
                throw err;
            }
            data = JSON.parse(dataJson);
        });
    }
};
