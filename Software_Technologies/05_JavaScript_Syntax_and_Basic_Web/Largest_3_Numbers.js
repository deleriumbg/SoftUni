function largest3Numbers(arr){
    let input = arr.map(Number).sort((a, b) => a - b);
    let count = Math.min(3, input.length)
    for (let i = 0; i < count; i++){
        console.log(input.pop())
    }
}

largest3Numbers(['10', '30', '15', '20', '50', '5'])