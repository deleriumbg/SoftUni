function addRemoveElements(arr){
    let result = [];
    for (let arrElement of arr) {
        let input = arrElement.split(' ');
        let command = input[0];
        let value = Number(input[1]);
        switch (command) {
            case 'add':
                result.push(value);
                break;
            case 'remove':
                result.splice(value, 1);
                break;
        }
    }
    console.log(result.join('\n'));
}


addRemoveElements([
    'add 3',
    'add 5',
    'remove 2',
    'remove 0',
    'add 7'
])