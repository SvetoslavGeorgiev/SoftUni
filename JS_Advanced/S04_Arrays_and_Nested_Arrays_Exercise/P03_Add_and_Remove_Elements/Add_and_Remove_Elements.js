function solve(input){

    let number = 0;

    let arr= [];

    for (let action of input) {

        if (action === 'add') {
            arr.push(++number)
        }else{
            number++;
            arr.pop();
        }
    }

    if (arr.length < 1) {
        return 'Empty';
    }

    return arr.join('\n');

}

console.log(solve(['add', 
'add', 
'add', 
'add']
))

console.log(solve(['add', 
'add', 
'remove', 
'add', 
'add']
));

console.log(solve(['remove', 
'remove', 
'remove']
));