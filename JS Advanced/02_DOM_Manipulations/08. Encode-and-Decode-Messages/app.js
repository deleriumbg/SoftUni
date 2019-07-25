function encodeAndDecodeMessages() {
    let buttons = document.getElementsByTagName('button');

    buttons[0].addEventListener('click', encode);
    buttons[1].addEventListener('click', decode);

    function encode() {
        let message = document.getElementsByTagName('textarea')[0].value;
        let encodedMessage = "";

        for (let i = 0; i < message.length; i++) {
            encodedMessage += String.fromCharCode(message.charCodeAt(i) + 1);
        }

        document.getElementsByTagName('textarea')[0].value = '';
        document.getElementsByTagName('textarea')[1].value = encodedMessage;
    }

    function decode() {
        let message = document.getElementsByTagName('textarea')[1].value;
        let decodedMessage = '';

        for (let i = 0; i < message.length; i++) {
            decodedMessage += String.fromCharCode(message.charCodeAt(i) - 1);
        }

        document.getElementsByTagName('textarea')[1].value = decodedMessage;
    }
}