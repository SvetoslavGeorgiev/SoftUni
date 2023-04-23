function RegExMatchToUppert(string){

    let result = string.toUpperCase()
    .match(/[A-Za-z0-9]+/ig)
    .join(', ');

    console.log(result);

}


// variant 2 same output


// function RegExMatchToUppert(string){

//     let result = string.toUpperCase()
//     .match(/\w+/gi)
//     .join(', ');

//     console.log(result);

// }


RegExMatchToUppert('Hi, h, 01, you?')
RegExMatchToUppert('HELLO')

