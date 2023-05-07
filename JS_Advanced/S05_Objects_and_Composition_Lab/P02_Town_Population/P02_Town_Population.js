function solve(input) {

    let registry = [];

    for (const el of input) {

        let tokens = el.split(" <-> ");

        let town = {};

        town.name = tokens[0];
        town.population = Number(tokens[1]);

        if (registry.length === 0) {
            registry.push(town)
        } else {

            for (let i = 0; i < registry.length; i++) {
                if (registry[i].name === town.name) {
                    registry[i].population += town.population;
                    break;
                } else {
                    registry.push(town)
                    break;
                }
            }
        }
    }

    return registry.map(x => `${x.name} : ${x.population}`).join("\n");

}

console.log(solve(['Sofia <-> 1200000',
    'Montana <-> 20000',
    'New York <-> 10000000',
    'Washington <-> 2345000',
    'Las Vegas <-> 1000000']
));