function solve(input) {

    let catalog = [];

    let sortedInput = input.sort((a, b) => a.localeCompare(b));

    for (const el of sortedInput) {

        let [currProduct, currPrice] = el.split(' : ');

        let product = {};

        let catalogLetter = currProduct[0];

        if (!catalog[catalogLetter]) {
            catalog[catalogLetter] = [];
        }

        product.name = currProduct;
        product.price = Number(currPrice);

        catalog[catalogLetter].push(product);

    }

    return Object.entries(catalog)
        .map(([key, value]) => `${key}\n${value.map(item => `  ${item.name}: ${item.price}`).join('\n')}`)
        .join('\n');

}

console.log(solve(['Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10']
));