function solve(input){

    let inputType = typeof(input);
    let result;

    if (inputType === 'number') {
        result = (Math.pow(input, 2) * Math.PI).toFixed(2);
    }
    else {

        result = `We can not calculate the circle area, because we receive a ${inputType}.`
        
    }
    
    console.log(result);
    
}

solve(5);
solve('Pesho');