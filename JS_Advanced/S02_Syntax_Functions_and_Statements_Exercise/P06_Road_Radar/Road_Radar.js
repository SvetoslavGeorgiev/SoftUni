function Radar(speed, location) {

    let limit;
    let difference;
    let status;

   switch (location) {
        case 'motorway':
            limit = 130;
            GetDiferenceAndStatus(speed, limit);
            break;
        case 'interstate':
            limit = 90;
            GetDiferenceAndStatus(speed, limit);
            break;
        case 'city':
            limit = 50;
            GetDiferenceAndStatus(speed, limit);
            break;
        case 'residential':
            limit = 20;
            GetDiferenceAndStatus(speed, limit);
            break;
    }

    function GetDiferenceAndStatus(speed, limit) {

        if (speed > limit) {
            difference = speed - limit;
            switch (difference > 0) {
                case difference <= 20:
                    status = 'speeding';
                    break;
                case difference > 20 && difference <= 40:
                    status = 'excessive speeding';
                    break;
                case difference > 40:
                    status = 'reckless driving';
                    break;
            }

        }

    }


    var result = limit >= speed ? `Driving ${speed} km/h in a ${limit} zone` :
        `The speed is ${difference} km/h faster than the allowed speed of ${limit} - ${status}`;


    console.log(result);

}

Radar(40, 'city');
Radar(50, 'city');
Radar(200, 'motorway');
Radar(169, 'motorway');
Radar(170, 'motorway');
Radar(120, 'interstate');
Radar(21, 'residential');