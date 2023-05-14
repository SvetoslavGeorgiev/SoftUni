function solve(input) {

    let arrNumbers = [];

    let arrOperators = [];

    while (input.length >= 1) {

        let currElement = input.shift()

        if (Number.isInteger(currElement)) {
            arrNumbers.push(currElement);
        } else if (!Number.isInteger(currElement) && arrNumbers.length >= 2) {
            const secondNumber = arrNumbers.pop();
            const firstNumber = arrNumbers.pop();
            let sum = 0;
            if (arrOperators.length == 0) {
                sum = eval(firstNumber + currElement + secondNumber);
            }else{
                arrOperators.push(currElement);
                sum = eval(firstNumber + arrOperators.shift() + secondNumber);
            }
            arrNumbers.push(sum);
        }else if (!Number.isInteger(currElement)){
            arrOperators.push(currElement);
        }
    }

    if (arrOperators.length > 0) {
        return 'Error: not enough operands!'
    }
    else if (arrNumbers.length > 1){
        return 'Error: too many operands!'
    }

    return arrNumbers[0];
}

console.log(solve([5,
    3,
    4,
    '*',
    '-']
));

console.log(solve([7,
33,
8,
'-']
));