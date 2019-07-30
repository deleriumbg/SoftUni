function attachEvents(){
    const url = 'https://judgetests.firebaseio.com/';
    $('#submit').click(getWeather);

    async function getWeather(){
        try {
            let weather = await $.ajax({
                method: 'GET',
                url: url + 'locations.json'
            });
            let input = $('#location').val();
            let code = weather.filter(t => t.name === input)[0].code;
            let locationWeather = await $.ajax({
                method: 'GET',
                url: `${url}forecast/today/${code}.json`
            });
            console.log(locationWeather);

            let symbol = locationWeather.forecast.condition === "Sunny" ? '&#x2600;' :
                         locationWeather.forecast.condition === "Partly sunny" ? '&#x26C5;' :
                         locationWeather.forecast.condition === "Overcast" ? '&#x2601;' : '&#x2614;';

            $('#current').append($(`<span class="condition symbol">${symbol}</span>`));
            let forecastDetails = $('<span class="condition"></span>')
                .append($(`<span class="forecast-data">${locationWeather.name}</span>`))
                .append($(`<span class="forecast-data">${locationWeather.forecast.low}&#176;/${locationWeather.forecast.high}&#176;</span>`))
                .append($(`<span class="forecast-data">${locationWeather.forecast.condition}</span>`));
            $('#current').append(forecastDetails);
            $('#forecast').css('display', 'block');

            let upcomingWeather = await $.ajax({
                method: 'GET',
                url: `${url}forecast/upcoming/${code}.json`
            });
            console.log(upcomingWeather);

            for (const upcoming of upcomingWeather.forecast) {
                $('#upcoming').append($('<span class="upcoming">')
                    .append($(`<span class="symbol">${symbol}</span>`))
                    .append($(`<span class="forecast-data">${upcoming.low}&#176;/${upcoming.high}&#176;</span>`))
                    .append($(`<span class="forecast-data">${upcoming.condition}</span>`)))
            }
        } catch(err) {
            console.error(err);
        }
    }
}