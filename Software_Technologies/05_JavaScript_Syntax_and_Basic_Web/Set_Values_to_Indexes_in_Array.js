function setValuesToIndexesInArray(arr){
    let length = Number(arr.shift())
    let result = new Array(length).fill(0);
    for (let arrElement of arr) {
        let input = arrElement.split(' - ');
        let index = input[0];
        let value = input[1];
        result[index] = value;
    }
    console.log(result.join('\n'));
}

setValuesToIndexesInArray([
    '3',
    '0 - 5',
    '1 - 6',
    '2 - 7'
])