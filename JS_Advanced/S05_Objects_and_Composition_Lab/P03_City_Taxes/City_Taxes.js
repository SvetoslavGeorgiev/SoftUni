function solve(city, population, treasury) {

    let town = {
        name: city,
        population: population,
        treasury: treasury,
        taxRate: 10,
        collectTaxes() {
            this.treasury += this.population * this.taxRate;
        },
        applyGrowth(percecntage) {
            this.population *= (percecntage / 100) + 1;
        },
        applyRecession(percecntage) {
            this.treasury *= 1 - (percecntage / 100);
        }
    };

    return town;

}

const city =
  solve('Tortuga',
  7000,
  15000);
city.collectTaxes();
console.log(city.treasury);
city.applyGrowth(5);
console.log(city.population);
city.applyRecession(5);
console.log(city.treasury);

