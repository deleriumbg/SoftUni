function argumentInfo() {
    let types = {};
    for (const argument of arguments) {
        console.log(`${typeof(argument)}: ${argument}`);
        if (types[typeof(argument)]) {
            types[typeof(argument)]++;
        } else {
            types[typeof(argument)] = 1;
        }

    }
    let typeCounter = Object.entries(types).sort((a, b) => {
        return b[1] - a[1]
    });
    for (const type of typeCounter) {
        console.log(`${type[0]} = ${type[1]}`);
    }
}

argumentInfo('cat', 42, function () { console.log('Hello world!'); });
