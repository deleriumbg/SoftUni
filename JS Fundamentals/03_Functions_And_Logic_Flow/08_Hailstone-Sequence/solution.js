function getNext() {
    let number = Number(document.getElementById('num').value);
    let result = hailStoneSeq(number);
    let resultElement = document.getElementById('result');

    resultElement.innerHTML = result + ' ';

    function hailStoneSeq(n) {
        var seq = [n];

        while (n !== 1) {
            if (n % 2 === 0) n /= 2;
            else n = (n * 3) + 1;

            seq.push(n)
        }

        return seq.join(' ')
    }
}