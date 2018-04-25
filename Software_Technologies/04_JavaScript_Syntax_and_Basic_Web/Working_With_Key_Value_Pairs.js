function workingWithKeyValuePairs(arr){
    let stopCommand = arr.pop();
    let obj = {};
    for (let arrElement of arr) {
        let input = arrElement.split(' ');
        let key = input[0];
        let value = input[1];
        obj[key] = value;
    }
    if (obj.hasOwnProperty(stopCommand)) {
        console.log(obj[stopCommand])
    }
    else{
        console.log('None');
    }
}

workingWithKeyValuePairs([
    'key value',
    'key eulav',
    'test tset',
    'key'
])