function attachEvents() {
    debugger;
    const url = `https://messenger-4f880.firebaseio.com/.json`;

    $('#submit').click(createMessage);
    $('#refresh').click(loadMessage);

    function createMessage() {
        let data = {
            author: $('#author').val(),
            content: $('#content').val(),
            timestamp: Date.now()
        };

         $.ajax({
             type: 'POST',
             url,
             data: JSON.stringify(data),
             success: loadMessage
         });
        //$.post(url + '.json', JSON.stringify(data)).then(loadMessage);
    }

    function loadMessage() {
        $.ajax({
            method: 'GET',
            url,
            success: displayMessage
        });
        //$.get(url + '.json').then(displayMessage)
    }

    function displayMessage(req) {
        $('#messages').empty();
        let orderedMessages = {};
        req = Object.keys(req)
            .sort((a, b) => a.timestamp - b.timestamp)
            .forEach(m => orderedMessages[m] = req[m]);

        for (let message of Object.keys(orderedMessages)) {
            $('#messages').append(`${orderedMessages[message].author}: ${orderedMessages[message].content}\n`);
        }
    }

    loadMessage();
}