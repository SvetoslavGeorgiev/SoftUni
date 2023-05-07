function solve(input) {

    let products = {};

    for (let i = 0; i < input.length; i += 2) {

        let product = {};
        product.name = input[i];
        product.calories = input[i + 1];

        products[product.name] = product.calories;
    }

    return products;

}


console.log(solve(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']));
console.log(solve(['Potato', '93', 'Skyr', '63', 'Cucumber', '18', 'Milk', '42']));