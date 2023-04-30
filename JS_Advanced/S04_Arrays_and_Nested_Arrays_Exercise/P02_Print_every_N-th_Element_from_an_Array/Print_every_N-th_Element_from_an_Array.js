function solve(input, step) {

    let arr = [];

    for (let index = 0; index < input.length; index += step) {
        arr.push(input[index]);
    }

    return arr;

}

console.log(solve(['5', 
'20', 
'31', 
'4', 
'20'], 
2
));


console.log(solve(['dsa',
'asd', 
'test', 
'tset'], 
2
));


console.log(solve(['1', 
'2',
'3', 
'4', 
'5'], 
6
));