function sortArray(arr, sortType) {
    switch (sortType) {
        case 'asc':
            return arr.sort((a, b) => {
                return a - b});
        case 'desc':
            return arr.sort((a, b) => {
                return b - a})        
        default:
            break;
    }
}

sortArray([14, 7, 17, 6, 8], 'asc');