function solve(input){

    input.sort((a, b) => a.length - b.length || a.localeCompare(b));

    return input.join('\n');
}


console.log(solve(['test', 
'Deny', 
'omen', 
'Default'])
);