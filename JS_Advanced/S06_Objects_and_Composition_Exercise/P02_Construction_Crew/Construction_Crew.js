function solve(obj) {
    if (obj.dizziness) {
        obj.dizziness = false;
        obj.levelOfHydrated += obj.weight * obj.experience * 0.1;
    }
    return obj;
}

console.log(solve({ weight: 120,
    experience: 20,
    levelOfHydrated: 200,
    dizziness: true }
));

console.log(solve({ weight: 95,
    experience: 3,
    levelOfHydrated: 0,
    dizziness: false }
));