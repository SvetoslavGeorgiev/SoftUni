function solve(n, p1, p2, p3, p4, p5) {
    let number = Number(n);

    let chop = (number) => number / 2;
    let dice = (number) => Math.sqrt(number);
    let spice = (number) => number + 1;
    let bake = (number) => number * 3;
    let fillet = (number) => number * 0.8;

    let operationsArray = [p1, p2, p3, p4, p5];

    for (let i = 0; i < operationsArray.length; i++) {
        let currentOperation = operationsArray[i];

        switch (currentOperation) {
            case 'chop': number = chop(number);
                break;
            case 'dice': number = dice(number);
                break;
            case 'spice': number = spice(number);
                break;
            case 'bake': number = bake(number);
                break;
            case 'fillet': number = fillet(number);
                break;
        }

        console.log(number);
    }
}

solve('32', 'chop', 'chop', 'chop', 'chop', 'chop');
solve('9', 'dice', 'spice', 'chop', 'bake', 'fillet');