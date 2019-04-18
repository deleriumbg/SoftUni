function solve(arr){
    let delimiter = arr.pop();
    console.log(arr.join(delimiter))
}

solve(['One',
    'Two',
    'Three',
    'Four',
    'Five',
    '-']
);