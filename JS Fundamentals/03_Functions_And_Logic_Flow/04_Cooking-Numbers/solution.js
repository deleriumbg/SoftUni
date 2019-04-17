function solve() {
    let buttons = document.getElementsByTagName("button");
    let outputElement = document.getElementById("output");

    for (const button of buttons) {
        button.addEventListener("click", cook);
    }

    function cook(e) {
        let button = e.target;
        let number;

        if (!outputElement.textContent) {
            number = Number(document.querySelector("#exercise input").value);
        } else {
            number = Number(outputElement.textContent);
        }

        if (button.textContent === "Chop") {
            number = chop(number);
        } else if (button.textContent === "Dice") {
            number = dice(number);
        } else if (button.textContent === "Spice") {
            number = spice(number);
        } else if (button.textContent === "Bake") {
            number = bake(number);
        } else if (button.textContent === "Fillet") {
            number = fillet(number);
        }
    }

    function chop(number) {
        number /= 2;
        outputElement.textContent = number;
        return number;
    }

    function dice(number) {
        number = Math.sqrt(number);
        outputElement.textContent = number;
        return number;
    }

    function spice(number) {
        number++;
        outputElement.textContent = number;
        return number;
    }

    function bake(number) {
        number *= 3;
        outputElement.textContent = number;
        return number;
    }

    function fillet(number) {
        number *= 0.8;
        outputElement.textContent = number;
        return number;
    }
}
