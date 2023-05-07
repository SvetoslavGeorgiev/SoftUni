function solve(city, population, treasury){

    let town = {};

    town.name = city;
    town.population = population;
    town.treasury = treasury;

    return town;

}

console.log(solve('Tortuga',
7000,
15000
));