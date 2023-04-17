function solve(array) {
    let numbersArray = array.map(Number);
    let sum = numbersArray.reduce((a, b) => a + b);

    let inverseValuesSum = 0;

    for (let i = 0; i < numbersArray.length; i++) {
        inverseValuesSum += 1 / numbersArray[i];
    }

    let arrayAsString = array.join('');

    console.log(sum);
    console.log(inverseValuesSum);
    console.log(arrayAsString);
}

solve([2, 4, 8, 16]);