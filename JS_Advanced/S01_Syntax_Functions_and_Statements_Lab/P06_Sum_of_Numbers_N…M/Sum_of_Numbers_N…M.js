function solve(numAsString1, numAsString2) {
    let num1 = Number(numAsString1);
    let num2 = Number(numAsString2);

    let sum = 0;

    for (let i = num1; i <= num2; i++) {
        sum += i;
    }

    return sum;
}

let result = solve('-8', '20');
console.log(result);