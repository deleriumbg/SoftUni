function increment(selector) {
    let container = $(selector);
    let fragment = $('div');
    let textArea = $('<textarea>');
    let incrementBtn = $('<button>');
    let addBtn = $('<button>');
    let list = $('<ul>');

    textArea.appendTo(fragment);
    incrementBtn.appendTo(fragment);
    addBtn.appendTo(fragment);
    list.appendTo(fragment);
    fragment.appendTo(container);

    textArea.addClass('counter').val(0).attr('disabled', true);
    incrementBtn.addClass('btn').attr('id', 'incrementBtn').text('Increment');
    addBtn.addClass('btn').attr('id', 'addBtn').text('Add');
    list.addClass('results');
}

$('body')
    .on('click', '#incrementBtn', function () {
        let textAreaValue = parseInt($('textarea').val());
        $('textarea').val(textAreaValue + 1);
    })
    .on('click', '#addBtn', function () {
        let textAreaValue = $('textarea').val();
        let li = $('<li>');
        li.text(textAreaValue);
        li.appendTo('ul');
    });

increment('#wrapper');
