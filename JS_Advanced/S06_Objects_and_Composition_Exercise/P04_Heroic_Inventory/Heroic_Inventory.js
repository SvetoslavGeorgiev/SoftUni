function solve(input) {

    let heroes = [];

    for (const element of input) {

        let hero = {};

        let tokens = element.split(' / ')
        hero.name = tokens[0];
        hero.level = Number(tokens[1]);
        hero.items = tokens[2] ? tokens[2].split(', ') : [];
        heroes.push(hero);
        
    }
    return JSON.stringify(heroes);
}


console.log(solve(['Isacc / 25 / Apple, GravityGun',
'Derek / 12 / BarrelVest, DestructionSword',
'Hes / 1 / Desolator, Sentinel, Antara']
));