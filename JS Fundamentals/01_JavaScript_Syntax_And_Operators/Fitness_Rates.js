function solve(day, service, time) {
    let isWeekday = (day === 'Monday' || day === 'Tuesday' || day === 'Wednesday' || day === 'Thursday' || day === 'Friday');
    let isWeekend = (day === 'Saturday' || day === 'Sunday');

    let isMorning = time >= 8 && time <= 15;
    let isAfternoon = time >= 15 && time <= 22;

    let price = 0;

    if (isWeekday && (isMorning || isAfternoon)) {
        switch (service) {
            case 'Fitness': price = isMorning ? 5 : 7.50; break;
            case 'Sauna': price = isMorning ? 4 : 6.50; break;
            case 'Instructor': price = isMorning ? 10 : 12.50; break;
        }
    }
    else if (isWeekend && (isMorning || isAfternoon)) {
        switch (service) {
            case 'Fitness': price = 8; break;
            case 'Sauna': price = 7; break;
            case 'Instructor': price = 15; break;
        }
    }

    console.log(price);
}

solve('Monday', 'Sauna', 15.30);