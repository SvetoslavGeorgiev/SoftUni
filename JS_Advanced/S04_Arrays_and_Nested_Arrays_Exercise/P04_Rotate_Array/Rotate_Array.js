function rotateArray(input, numberOfiterations){

    for (let index = 0; index < numberOfiterations; index++) {
        let curElement = input.pop();
        input.unshift(curElement)
    }

    return input.join(' ');

}

console.log(rotateArray(['1', 
'2', 
'3', 
'4'], 
2
));

console.log(rotateArray(['Banana', 
'Orange', 
'Coconut', 
'Apple'], 
15
));





