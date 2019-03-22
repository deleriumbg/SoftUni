function solve(number) {
    let sameNumbers = true;
    let numAsArray = number.toString();
    let sum = Number(numAsArray[0]);

    for (let i = 1; i < numAsArray.length; i++) {
        sum += Number(numAsArray[i]);
        if (numAsArray[i - 1] !== numAsArray[i]) {
            sameNumbers = false;
        }
    }
    console.log(sameNumbers);
    console.log(sum);
}

solve(2222222);