function multiplyDivideANumber(arr){
    let N = Number(arr[0]);
    let X = Number(arr[1]);
    if (X >= N) {
        console.log(N * X)
    }
    else{
        console.log(N / X)
    }
}

multiplyDivideANumber([
    '144',
    '12'
])