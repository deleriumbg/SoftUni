function solve() {
    let button = document.getElementsByTagName('button')[0];
    let allNumbers = document.getElementById('allNumbers');
    let numbers = [];

    button.addEventListener('click', getNumbers);

    function getNumbers() {
        let input = document.getElementsByTagName('input')[0].value;
        numbers = input.split(' ');
        console.log(numbers);

        if (numbers.length < 6 || numbers.length > 6) {
            return;
        }

        numbers.forEach(element => {
            if (element < 1 || element > 49) {
                return;
            }
        });

        for (let i = 1; i <= 49; i++) {
            let div = document.createElement('div');
            div.textContent = i;
            div.setAttribute('class', 'numbers');

            numbers.forEach(element => {
                if (element === div.textContent) {
                    div.style.backgroundColor = 'orange';
                }
            });
            allNumbers.appendChild(div);
        }
        document.getElementsByTagName('input')[0].setAttribute('disabled', 'true');
        document.getElementsByTagName('button')[0].setAttribute('disabled', 'true');
    }
}