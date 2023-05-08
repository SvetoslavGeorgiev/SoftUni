function solve(input) {
    let towns = [];

    for (const element of input) {
        let [town, product, price] = element.split(' | ');
        price = Number(price);

        let currentTown = towns.find(x => x.product === product);
        if (currentTown) {

            if (price < currentTown.price) {
                currentTown.price = price;
                currentTown.town = town;
            }
        }
        else {
            currentTown = { product, price, town };
            towns.push(currentTown);
        }
    }

    return towns.map(x => `${x.product} -> ${x.price} (${x.town})`).join('\n');

}

console.log(solve(['Sample Town | Sample Product | 1000',
    'Sample Town | Orange | 2',
    'Sample Town | Peach | 1',
    'Sofia | Orange | 3',
    'Sofia | Peach | 2',
    'New York | Sample Product | 1000.1',
    'New York | Burger | 10']
));