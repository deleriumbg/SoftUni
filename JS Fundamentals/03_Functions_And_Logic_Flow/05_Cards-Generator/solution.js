function solve() {
    const cardValues = ["2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"];
    let cardsSectionElement = document.getElementById("cards");
    let button = document.getElementsByTagName("button")[0];
    button.addEventListener("click", getCards);

    function getCards() {
        let from = document.getElementById("from").value;
        let to = document.getElementById("to").value;
        let suitInput = document.querySelector("#exercise select").value.split(" ");
        let unicode = suitInput[1];

        for (let i = cardValues.indexOf(from); i <= cardValues.indexOf(to); i++) {
            let divElement = document.createElement("div");
            divElement.classList.add("card");

            let firstSuitCodeElement = document.createElement("p");
            firstSuitCodeElement.textContent = unicode;

            let secondSuitCodeElement = document.createElement("p");
            secondSuitCodeElement.textContent = unicode;

            let cardValueElement = document.createElement("p");
            cardValueElement.textContent = cardValues[i];

            divElement.appendChild(firstSuitCodeElement);
            divElement.appendChild(cardValueElement);
            divElement.appendChild(secondSuitCodeElement);

            cardsSectionElement.appendChild(divElement);
        }
    }
}