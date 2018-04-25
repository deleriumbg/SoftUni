function storingObjects(arr){
    for (let arrElement of arr) {
        let input = arrElement.split(' -> ');
        let obj = {};
        obj.name = input[0];
        obj.age = input[1];
        obj.grade = input[2];
        console.log(`Name: ${obj.name}`);
        console.log(`Age: ${obj.age}`);
        console.log(`Grade: ${obj.grade}`);
    }

}

storingObjects([
    'Pesho -> 13 -> 6.00',
    'Ivan -> 12 -> 5.57',
    'Toni -> 13 -> 4.90'
])