function sumsByTown(arr){
    let input = arr.map(line => JSON.parse(line));
    let towns = {};
    for (let entry of input){
        if (towns[entry.town] === undefined){
            towns[entry.town] = 0;
        }
        towns[entry.town] += entry.income;
    }
    let townNames = Object.keys(towns).sort();
    for (let city of townNames) {
        console.log(`${city} -> ${towns[city]}`)
    }
}

sumsByTown([
    '{"town":"Sofia","income":200}',
    '{"town":"Varna","income":120}',
    '{"town":"Pleven","income":60}',
    '{"town":"Varna","income":70}'
])