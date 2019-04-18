function solve(matrix){
    let rowSum = 0;
    for (let row = 0; row < matrix.length; row++) {
        let currentRowSum = 0;
        for (let col = 0; col < matrix[row].length; col++) {
            currentRowSum += matrix[row][col];
        }
        if (row === 0) {
            rowSum = currentRowSum;
        } else if (currentRowSum !== rowSum) {
            return false;
        }
    }

    for (let col = 0; col < matrix[0].length; col++) {
        let currentColSum = 0;
        for (let row = 0; row < matrix.length; row++) {
            currentColSum += matrix[row][col];
        }
        if (currentColSum !== rowSum) {
            return false;
        }
    }

    return true;
}

console.log(solve([[4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]]
));