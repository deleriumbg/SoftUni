function validate() {
    const weights = [2, 4, 8, 5, 10, 9, 7, 3, 6];
    let response = document.getElementById("response");
    let button = document.getElementsByTagName("button")[0];

    button.addEventListener("click", validateNumber);

    function validateNumber() {
        let inputNumber = Number(document.querySelector("#exercise input").value);
        let lastDigit = inputNumber % 10;
        let firstNineDigits = inputNumber.toString().substr(0, 9);

        let sum = 0;
        for (let i = 0; i < firstNineDigits.length; i++) {
            sum += Number(firstNineDigits[i]) * weights[i];
        }

        let result = sum % 11;
        if(result === 10){
            result = 0;
        }

        if(result === lastDigit){
            response.textContent = "This number is Valid!";
        } else{
            response.textContent = "This number is NOT Valid!";
        }

        inputNumber.textContent = "";
    }
}