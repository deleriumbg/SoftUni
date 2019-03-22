function solve(numberOfSteps, footprintInMeters, speedKmpH) {
    let speedInMpS = (speedKmpH * 1000) / 3600;
    let distanceInMeters = numberOfSteps * footprintInMeters;
    let timeInSeconds = (Math.floor(distanceInMeters / 500) * 60) + (distanceInMeters / speedInMpS);

    let hours = Math.floor(timeInSeconds / 3600);
    timeInSeconds %= 3600;
    let minutes = Math.floor(timeInSeconds / 60);
    let seconds = Math.round(timeInSeconds % 60);

    minutes = String(minutes).padStart(2, "0");
    hours = String(hours).padStart(2, "0");
    seconds = String(seconds).padStart(2, "0");
    console.log(`${hours}:${minutes}:${seconds}`);

    /*let date = new Date(null);
    date.setSeconds(timeInSeconds);
    let result = date.toISOString().substr(11, 8);
    console.log(result);*/
}

solve(2564, 0.70, 5.5);