function solve() {
    let selectMenuToElement = document.getElementById('selectMenuTo');
    selectMenuToElement.children[0].value = 'binary';
    selectMenuToElement.children[0].textContent = 'Binary';

    let hexadecimalOptionElement = document.createElement('option');
    hexadecimalOptionElement.value = 'hexadecimal';
    hexadecimalOptionElement.textContent = 'Hexadecimal';

    selectMenuToElement.appendChild(hexadecimalOptionElement);

    let button = document.getElementsByTagName('button')[0];
    button.addEventListener('click', convert);

    function convert() {
        let result = document.getElementById('result');
        let input = document.getElementById('input');
        if(selectMenuToElement.value === 'binary'){
            result.value = Number(input.value).toString(2);
        } else if(selectMenuToElement.value === 'hexadecimal'){
            result.value = parseInt(input.value).toString(16).toUpperCase();
        }
    }
}