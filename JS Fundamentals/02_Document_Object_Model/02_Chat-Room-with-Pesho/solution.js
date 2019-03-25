function solve() {
    let buttons = document.getElementsByTagName('button');

    for (let button of buttons) {
        button.addEventListener('click', chat);
    }

    function chat(e){
        let divElement = document.createElement('div');
        let spanElement = document.createElement('span');
        let pElement = document.createElement('p');
        let myMessage = document.getElementById('myChatBox');
        let peshoMessage = document.getElementById('peshoChatBox');

        let senderBtn = e.target.name;
        if (senderBtn === 'myBtn') {
            spanElement.textContent = 'Me';
            pElement.textContent = myMessage.value;
            divElement.style.textAlign = 'left';
        } else if (senderBtn === 'peshoBtn') {
            spanElement.textContent = 'Pesho';
            pElement.textContent = peshoMessage.value;
            divElement.style.textAlign = 'right';
        }

        divElement.appendChild(spanElement);
        divElement.appendChild(pElement);
        document.getElementById('chatChronology').appendChild(divElement);

        myMessage.value = "";
        peshoMessage.value = "";
    }
}