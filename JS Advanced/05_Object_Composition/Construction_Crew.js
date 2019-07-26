function solve(worker){
    if (!worker.dizziness) {
        return worker;
    }
    let requiredWater = 0.1 * +worker.weight * +worker.experience;
    worker.levelOfHydrated += requiredWater;
    worker.dizziness = false;
    return worker;
}


console.log(solve({
        weight: 80,
        experience: 1,
        levelOfHydrated: 0,
        dizziness: true
    }
));