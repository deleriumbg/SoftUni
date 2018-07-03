function turnObjectIntoJsonString(arr){
    let obj = {};
    for (let arrElement of arr) {
        let input = arrElement.split(' -> ');
        let key = input[0];
        let value = input[1];
        if (!isNaN(value)) {
            value = Number(input[1])
        }
        obj[key] = value;
    }
    let result = JSON.stringify(obj);
    console.log(result);
}

turnObjectIntoJsonString([
    'name -> Angel',
    'surname -> Georgiev',
    'age -> 20',
    'grade -> 6.00',
    'date -> 23/05/',
    'town -> Sofia'
])