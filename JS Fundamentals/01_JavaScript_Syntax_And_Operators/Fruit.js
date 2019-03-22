function solve(type, weight, pricePerKg) {
    let weightInKg = weight / 1000;
    console.log(`I need ${(weightInKg * pricePerKg).toFixed(2)} leva to buy ${weightInKg.toFixed(2)} kilograms ${type}.`)
}

solve('orange', 2500, 1.80);