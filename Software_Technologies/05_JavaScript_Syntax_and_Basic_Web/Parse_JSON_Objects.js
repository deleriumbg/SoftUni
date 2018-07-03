function parseJsonObjects(arr){
    for (let arrElement of arr) {
        let obj = JSON.parse(arrElement);
        console.log(`Name: ${obj.name}`);
        console.log(`Age: ${obj.age}`);
        console.log(`Date: ${obj.date}`);
    }
}

parseJsonObjects([
    '{"name":"Gosho","age":10,"date":"19/06/2005"}',
    '{"name":"Tosho","age":11,"date":"04/04/2005"}'
])