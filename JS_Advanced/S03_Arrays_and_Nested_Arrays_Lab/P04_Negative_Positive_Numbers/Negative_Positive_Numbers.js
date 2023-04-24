function splitToNegativeAndPositiveNumbers(input){

    let negativeNumber = input.filter(x => x < 0)

    negativeNumber.reverse().forEach(x => console.log(x))

    let positiveNumbers = input.filter(x => x >= 0)

    positiveNumbers.forEach(x => console.log(x))

}


splitToNegativeAndPositiveNumbers([7, -2, 8, 9])
splitToNegativeAndPositiveNumbers([3, -2, 0, -1])