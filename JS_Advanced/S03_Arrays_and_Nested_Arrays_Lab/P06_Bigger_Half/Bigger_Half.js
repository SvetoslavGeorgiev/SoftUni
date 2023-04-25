function solve(input){

    return input.sort((a, b) => a - b)
    .slice(input.length / 2, input.length);

}

console.log(solve([4, 7, 2, 5]));
console.log(solve([3, 19, 14, 7, 2, 19, 6]));