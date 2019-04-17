function solve() {
    let num = Number(document.getElementById("num").value);
    let resultElement = document.getElementById("result");
    let factors = [];

    for (let i = 1; i <= num / 2; i++) {
        if (num % i == 0) {
            factors.push(i);
        }
    }

    factors.push(num);
    resultElement.textContent = factors.join(" ");
    document.getElementById("num").textContent = "";
}