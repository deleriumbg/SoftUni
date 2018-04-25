function multipleValuesForAKey(arr){
    let stopCommand = arr.pop();
    let map = new Map();
    for (let arrElement of arr) {
        let input = arrElement.split(' ');
        let key = input[0];
        let value = input[1];
        if (!map.has(key)) {
            map.set(key, [])
        }
        map.get(key).push(value);
    }
    console.log(map.has(stopCommand) ? map.get(stopCommand).join('\n') : 'None');
}

multipleValuesForAKey([
    'key value',
    'key eulav',
    'test tset',
    'key'
])

multipleValuesForAKey([
    '3 bla',
    '3 alb',
    '2'
])