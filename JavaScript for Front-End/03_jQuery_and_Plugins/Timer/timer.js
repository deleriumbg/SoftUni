let timer;
$('#start-timer').on('click', function () {
    if (timer) {
        clearInterval(timer);
    }

    timer = setInterval(function () {
        let seconds = parseInt($('#seconds').text());
        let minutes = parseInt($('#minutes').text());
        let hours = parseInt($('#hours').text());

        if (seconds == 59) {
            $('#seconds').text('00');
            $('#minutes').text(minutes + 1);
        }
        else {
            $('#seconds').text(seconds + 1);
        }

        if (minutes == 59) {
            $('#minutes').text('00');
            $('#hours').text(hours + 1);
        }

        if (hours == 24) {
            $('#seconds').text('00');
            $('#minutes').text('00');
            $('#hours').text('00');
        }
    }, 1000)
});

$('#stop-timer').on('click', function () {
    clearInterval(timer);
})
