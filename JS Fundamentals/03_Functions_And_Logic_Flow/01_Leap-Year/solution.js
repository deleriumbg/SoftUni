function leapYear() {
    let button = document.getElementsByTagName("button")[0];
    button.addEventListener("click", checkLeapYear);

    function checkLeapYear(){
        let input = document.querySelector("#exercise input");
        let divOutput = document.querySelector("#year div");
        let h2Output = document.querySelector("#year h2");

        let year = Number(input.value);

        if(((year % 4 == 0) && (year % 100 != 0)) || (year % 400 == 0)){
            h2Output.textContent = "Leap Year";
        } else {
            h2Output.textContent = "Not Leap Year";
        }

        divOutput.textContent = year;
        input.value = "";
    }
}