function solve(n, k) {

    let finalArray = [1];

    for (let i = 1; i < n; i++) {
        
        let start = i - k < 0 
        ? 0 
        : i - k;
        finalArray.push(finalArray.slice(start).reduce((acc, num) => acc + num));
    }

    return finalArray;
}

console.log(solve(6, 3));
console.log(solve(8, 2));