function solve(fruit, weight, money) {
    let weightInKg = weight / 1000;
    let sum = money * weightInKg;

    console.log(`I need $${sum.toFixed(2)} to buy ${weightInKg.toFixed(2)} kilograms ${fruit}.`);
}


solve('orange', 2500, 1.80)