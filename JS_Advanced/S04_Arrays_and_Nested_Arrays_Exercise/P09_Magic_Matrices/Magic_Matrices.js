function solve(input){

    
    let rowSum = input[0].reduce((a, b) => a + b);

    for (let row = 0; row < input.length; row++) {
        let calSum = 0;

        for (let col = 0; col < input.length; col++) {
            calSum += input[row][col];
        }

        if (calSum !== rowSum) {

            return false;
            
        }
    }

    return true;

}

console.log(solve([
    [4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]]
   ))

console.log(solve([
    [11, 32, 45],
    [21, 0, 1],
    [21, 1, 1]]
   ))

console.log(solve([
    [1, 0, 0],
    [0, 0, 1],
    [0, 1, 0]]
   ));