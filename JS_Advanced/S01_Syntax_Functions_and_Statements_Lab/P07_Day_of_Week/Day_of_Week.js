function solve(dayOfWeek) {
    let result;

    switch(dayOfWeek){
        case 'Monday': 
            result = 1;
            break;
        case 'Tuesday': 
            result = 2;
            break;
        case 'Wednesday': 
            result = 3;
            break;
        case 'Thursday': 
            result = 4;
            break;
        case 'Friday': 
            result = 5;
            break;
        case 'Saturday': 
            result = 6;
            break;
        case 'Sunday': 
            result = 7;
            break;
        default : 
        result = 'error';
    }

    return result;
}

console.log(solve('Monday'));