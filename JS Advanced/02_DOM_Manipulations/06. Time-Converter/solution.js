function attachEventsListeners() {
    document.getElementById('daysBtn').addEventListener('click', convertDays);
    document.getElementById('hoursBtn').addEventListener('click', convertHours);
    document.getElementById('minutesBtn').addEventListener('click', convertMinutes);
    document.getElementById('secondsBtn').addEventListener('click', convertSeconds);

    function convertDays() {
        let days = Number(document.getElementById('days').value);
        document.getElementById('hours').value = days * 24;
        document.getElementById('minutes').value = days * 24 * 60;
        document.getElementById('seconds').value = days * 24 * 60 * 60;
    }

    function convertHours() {
        let hours = Number(document.getElementById('hours').value);
        document.getElementById('days').value = hours / 24;
        document.getElementById('minutes').value = hours * 60;
        document.getElementById('seconds').value = hours * 60 * 60;
    }

    function convertMinutes() {
        let minutes = Number(document.getElementById('minutes').value);
        document.getElementById('days').value = minutes / 24 / 60;
        document.getElementById('hours').value = minutes / 60;
        document.getElementById('seconds').value = minutes * 60;
    }

    function convertSeconds() {
        let seconds = Number(document.getElementById('seconds').value);
        document.getElementById('days').value = seconds / 24 / 60 / 60;
        document.getElementById('hours').value = seconds / 60 / 60;
        document.getElementById('minutes').value = seconds / 60;
    }
}