function binarySearch() {
    let arr = document.getElementById('arr').value.split(', ');
    let num = document.getElementById('num').value;
    let resultElement = document.getElementById('result');

    if (arr.indexOf(num) !== -1) {
        resultElement.innerHTML = `Found ${num} at index ${arr.indexOf(num)}`;
    } else {
        resultElement.innerHTML = `${num} is not in the array`;
    }
}