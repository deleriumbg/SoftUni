function productOf3Numbers(arr){
    let input = arr.map(Number);
    let counter = 0;
    input.forEach(x => {
        if (x < 0)
            counter++;
    });

    if (counter % 2 == 0){
        console.log('Positive');
    }
    else{
        console.log('Negative');
    }
}

productOf3Numbers(['2', '3', '-1'])