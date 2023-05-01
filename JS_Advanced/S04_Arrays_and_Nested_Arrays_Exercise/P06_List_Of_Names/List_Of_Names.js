function solve(input){

    return input.sort((a, b) => a.localeCompare(b))
                .forEach((x, y) => console.log(`${y + 1}.${x}`));

}


solve(["John", "Bob", "Christina", "Ema"]);