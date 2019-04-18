function solve(rows, cols){
    let matrix = [];

    for (let i = 0; i < rows; i++) {
        matrix[i] = [];

        for (let j = 0; j < cols; j++) {
            matrix[i][j] = 0;
        }
    }

    let currentRow = 0;
    let currentCol = 0;
    let direction = 'r';

    let counter = 1;

    for (let i = 0; i < rows * cols; i++) {
        matrix[currentRow][currentCol] = counter;
        counter++;

        if(direction === 'r'){
            if(currentCol + 1 >= cols || matrix[currentRow][currentCol + 1] !== 0){
                direction = 'd';
                currentRow++;
            } else {
                currentCol++;
            }
        } else if(direction === 'd'){
            if(currentRow + 1 >= rows || matrix[currentRow + 1][currentCol] !== 0){
                direction = 'l';
                currentCol--;
            } else{
                currentRow++;
            }
        } else if(direction === 'l'){
            if(currentCol - 1 < 0 || matrix[currentRow][currentCol - 1] !== 0){
                direction = 'u';
                currentRow--;
            } else {
                currentCol--;
            }
        } else if(direction === 'u'){
            if(currentRow - 1 < 0 || matrix[currentRow - 1][currentCol] !== 0){
                direction = 'r';
                currentCol++;
            } else {
                currentRow--;
            }
        }
    }

    for(let row of matrix){
        console.log(row.join(' '));
    }
}

solve(5, 5);