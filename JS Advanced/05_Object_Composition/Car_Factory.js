function solve(car){
    let smallEngine = { power: 90, volume: 1800 };
    let normalEngine = { power: 120, volume: 2400 };
    let monsterEngine = { power: 200, volume: 3500 };

    let hatchback = { type: 'hatchback', color: car.color };
    let coupe = { type: 'coupe', color: car.color };
    let wheelsize = +car.wheelsize;

    let customizedCar = {};
    customizedCar.model = car.model;

    if (car.power <= 90){
        customizedCar.engine = smallEngine;
    } else if (car.power <= 120) {
        customizedCar.engine = normalEngine;
    } else if (car.power <= 200){
        customizedCar.engine = monsterEngine;
    }

    if (car.carriage === 'hatchback'){
        customizedCar.carriage = hatchback;
    } else if (car.carriage === 'coupe'){
        customizedCar.carriage = coupe;
    }

    if (wheelsize % 2 !== 0) {
        customizedCar.wheels = [wheelsize, wheelsize, wheelsize, wheelsize];
    } else {
        customizedCar.wheels = [wheelsize - 1 , wheelsize - 1, wheelsize - 1, wheelsize - 1];
    }

    return customizedCar;
}

console.log(solve({ model: 'Opel Vectra',
    power: 110,
    color: 'grey',
    carriage: 'coupe',
    wheelsize: 17 }
));