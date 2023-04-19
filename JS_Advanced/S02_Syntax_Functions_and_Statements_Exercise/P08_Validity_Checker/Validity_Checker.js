function checkValidity(x1, y1, x2, y2) {

    let distance = function (x1, y1, x2 = 0, y2 = 0) {
        
        let isValid = false;

        let distX = Math.pow((x2 - x1), 2);
        let distY = Math.pow((y2 - y1), 2);

        let result = Math.sqrt(distX + distY);

        if (Number.isInteger(result)) {
            isValid = true;
        }

        return isValid;
    };

    let firstPointValidation = (distance(x1, y1)) ? 'valid' : 'invalid';
    console.log(`{${x1}, ${y1}} to {0, 0} is ${firstPointValidation}`);

    let secondPointValidation = (distance(x2, y2)) ? 'valid' : 'invalid';
    console.log(`{${x2}, ${y2}} to {0, 0} is ${secondPointValidation}`);

    let firstToSecondPointValidation = (distance(x1, y1, x2, y2)) ? 'valid' : 'invalid';
    console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is ${firstToSecondPointValidation}`);
}

checkValidity(3, 0, 0, 4);
checkValidity(2, 1, 1, 1);