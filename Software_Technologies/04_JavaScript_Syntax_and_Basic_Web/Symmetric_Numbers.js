function symmetricNumbers(arr){
    let num = arr[0];
    for (let i = 1; i <= num; i++) {
        let numberAsString = '' + i;
        if (numberAsString == [...numberAsString].reverse().join(''))
            console.log(i);
    }
}

symmetricNumbers(['100'])