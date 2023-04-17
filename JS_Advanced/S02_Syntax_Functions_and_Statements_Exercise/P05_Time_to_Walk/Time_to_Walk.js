function GetTimeForTheWalk(steps, footPrint, speed) {

    let distance = steps * footPrint / 1000;

    let breakTime = Math.floor(distance / 0.5);

    let timeInMimutes = (distance / speed) * 60;

    let seconds = Math.ceil((timeInMimutes - Math.floor(timeInMimutes)) * 60);

    let totalMinutes = Math.floor(timeInMimutes) + breakTime;

    let hours = 0;

    let finalHours = 0;

    if (totalMinutes >= 60) {

        hours = totalMinutes / 60;

        finalHours = Math.floor(hours);

        timeInMimutes = (hours - finalHours) * 60

        totalMinutes = Math.ceil(timeInMimutes);

    }

    let hoursAsString = finalHours >= 10 ? `${finalHours}` : `0${finalHours}`;
    let minutesAsString = totalMinutes >= 10 ? `${totalMinutes}` : `0${totalMinutes}`;
    let secondsAsString = seconds >= 10 ? `${seconds}` : `0${seconds}`;


    let time = `${hoursAsString}:${minutesAsString}:${secondsAsString}`

    console.log(time);

}



GetTimeForTheWalk(4000, 0.60, 5)
GetTimeForTheWalk(2564, 0.70, 5.5)
GetTimeForTheWalk(8000, 0.60, 5)
