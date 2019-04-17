function greatestCD() {
    let num1 = Number(document.getElementById("num1").value);
    let num2 = Number(document.getElementById("num2").value);
    let result = document.getElementById("result");

    result.textContent = gcd(num1, num2);

    function gcd(num1, num2) {
        if (!num2) {
            return num1;
        }

        return gcd(num2, num1 % num2);
    }
}