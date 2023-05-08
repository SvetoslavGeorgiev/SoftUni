function solve(obj) {

    car = {};

    let smallengine = { power: 90, volume: 1800 }
    let normalengine = { power: 120, volume: 2400 }
    let monsterengine = { power: 200, volume: 3500 }


    car.model = obj.model;
    car.engine = {};
    car.carriage = {};
    car.wheels = Array(4);

    let power = Number(obj.power);

    switch (true) {
        case power > 160:
            car.engine = monsterengine;
            break;
        case power > 105:
            car.engine = normalengine;
            break;
        case power < 106:
            car.engine = smallengine;
            break;
    }

    car.carriage.type = obj.carriage;
    car.carriage.color = obj.color;

    //variant 1
    //let wheelsize = obj.wheelsize % 2 == 0 ? obj.wheelsize - 1 : obj.wheelsize;

    // for (let i = 0; i < 4; i++) {
    //     car.wheels.push(wheelsize);
    // }


    //variant 2
    car.wheels.fill(obj.wheelsize % 2 == 0 ? obj.wheelsize - 1 : obj.wheelsize, 0)

    return car;

}


console.log(solve({
    model: 'VW Golf II',
    power: 90,
    color: 'blue',
    carriage: 'hatchback',
    wheelsize: 14
}
));