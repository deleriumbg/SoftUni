function validate() {
    const monthsArray = ["January", "February", "March", "April", "May", "June", "July", "August",
        "September", "October", "November", "December"];
    const weightPosition = [2, 4, 8, 5, 10, 9, 7, 3, 6];
    let button = document.getElementsByTagName("button")[0];
    let egnOutputElement = document.getElementById("egn");
    button.addEventListener("click", generate);

    function generate() {
        let egn = "";
        let year = document.getElementById("year").value;
        let month = document.getElementById("month").value;
        let day = document.getElementById("date").value;
        let gender;

        if (document.getElementById("male").checked) {
            gender = "2";
        } else {
            gender = "1";
        }

        let region = document.getElementById("region").value;

        let regionalCode = region.toString()[0] + region.toString()[1];

        egn += year.slice(2);
        egn += ("00" + (monthsArray.indexOf(month) + 1)).slice(-2);
        egn += ("00" + day).slice(-2);
        egn += regionalCode;
        egn += gender;

        let weightSum = getWeightSum(egn);

        let remainder = weightSum % 11;

        if (remainder === 10) {
            remainder = 0;
        }

        egn += remainder;

        egnOutputElement.textContent = `Your EGN is: ${egn}`;

        clearInput();

        function getWeightSum(egn) {
            let sum = 0;

            for (let i = 0; i < egn.length; i++) {
                sum += Number(egn[i] * weightPosition[i]);
            }

            return sum;
        }

        function clearInput() {
            document.getElementById("year").value = "";
            document.getElementById("month").value = "";
            document.getElementById("date").value = "";
            document.getElementById("region").value = "";
            document.getElementById("male").checked = false;
            document.getElementById("female").checked = false;
        }
    }
}