function solve(month, year) {
    let result = new Date(year, month, 0).getDate();
    return result;
}

console.log(solve('2', '2021'));