function solve(arr){
    let maxValue = -Infinity;
    for (let i = 0; i < arr.length; i++) {
        if (arr[i] >= maxValue) {
            maxValue = arr[i];
            console.log(arr[i]);
        }
    }
}

solve([1, 3, 8, 4, 10, 12, 3, 2, 24]);