function attachEvents() {
    const url = 'https://phonebook-nakov.firebaseio.com/phonebook';

    $('#btnCreate').click(createContact);
    $('#btnLoad').click(loadContact);

    function createContact() {
        let contact = {
            person: $('#person').val(),
            phone: $('#phone').val()
        };
        $('#person').val('');
        $('#phone').val('');

        $.ajax({
            type: 'POST',
            url: url + '.json',
            data: JSON.stringify(contact),
            success: loadContact
        });
    }

    function loadContact() {
        $.ajax({
            method: 'GET',
            url: url + '.json',
            success: displayContacts
        });
    }

    function displayContacts(req) {
        let phonebook = $('#phonebook');
        phonebook.empty();
        for (let contact of Object.keys(req)) {
            let li = $(`<li>`)
                .text(`${req[contact].person}: ${req[contact].phone} `)
                .append($('<button>[Delete]</button>').click(function () {
                    $.ajax({
                        method: "DELETE",
                        url: url + `/${contact}.json`
                    }).then(() => $(li).remove());
                }));
            phonebook.append(li);
        }
    }

    loadContact();
}