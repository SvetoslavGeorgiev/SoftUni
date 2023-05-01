function solve(input){

    let num = input[0];

    let result = [];

    input.reduce(function(prevVal, currVal){

        if (currVal >= num) {
            num = currVal
            prevVal.push(currVal)
        }

        return prevVal;

    }, result)

    return result;

}

console.log(solve([1, 
    3, 
    8, 
    4, 
    10, 
    12, 
    3, 
    2, 
    24]
));

console.log(solve([1, 
    2, 
    3,
    4]
));

console.log(solve([20, 
    3, 
    2, 
    15,
    6, 
    1]
));