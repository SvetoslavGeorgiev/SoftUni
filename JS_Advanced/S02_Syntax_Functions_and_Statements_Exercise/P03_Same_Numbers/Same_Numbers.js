function CheckIfSameNumber(input){
    let inputNumber = input.toString();
    let isSame = true;
    let sumOfDiget = 0;
    let digitToCompare = inputNumber[0];
    let lengthOfTheNumber = inputNumber.length;

    for (let index = 0; index  < lengthOfTheNumber; index++) {

        let currnetDiget = inputNumber[index]
        sumOfDiget += Number(currnetDiget) // +inputNumber[index] is the same as Number(inputNumber[index])

        if (digitToCompare !== currnetDiget) {
            isSame = false;
        }
        
    }

    console.log(isSame);
    console.log(sumOfDiget);
}

CheckIfSameNumber(2222222);
CheckIfSameNumber(1234);
CheckIfSameNumber(222);
CheckIfSameNumber(33333);
CheckIfSameNumber(4844);