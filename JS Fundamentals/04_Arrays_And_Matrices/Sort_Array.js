function solve(arr){
    let sortedArr = arr.sort((a, b) => {
        return a.length - b.length || a.localeCompare(b);
    });
    console.log(sortedArr.join('\n'))
}

solve(['alpha',
    'beta',
    'gamma']
);