function solve(arr){
    return arr.filter((x, y) => y % 2 != 0)
    .reverse()
    .map(x => x * 2)
}



console.log(solve([10, 15, 20, 25]));
console.log(solve([3, 0, 10, 4, 7, 3]));
