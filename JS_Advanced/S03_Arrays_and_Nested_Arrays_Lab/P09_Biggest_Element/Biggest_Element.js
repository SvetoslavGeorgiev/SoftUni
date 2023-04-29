function solve(input){

    return Number(input.filter(x => x.sort((a, b) => b - a))
                            .map(x => x[0])
                            .sort((a, b) => b - a)
                            .slice(0, 1));

}


console.log(solve(
    [[20, 50, 10],
    [8, 33, 145]]
));

console.log(solve(
    [[3, 5, 7, 12],
    [-1, 4, 33, 2],
    [8, 3, 0, 4]]
))

