function solve(name, age, weight, height){
    let patient = {
        name,
        personalInfo: {
            age,
            weight,
            height
        },
        BMI: +Math.round(weight / Math.pow(height / 100, 2)),
        status: ''
    };

    patient.status = getBmiStatus(patient.BMI);
    if (patient.status === 'obese'){
        patient.recommendation = 'admission required'
    }
    return patient;

    function getBmiStatus(bmi){
        switch (true) {
            case (bmi < 18.5):
                return 'underweight';
            case (bmi < 25):
                return 'normal';
            case (bmi < 30):
                return 'overweight';
            case (bmi >= 30):
                return 'obese';
        }
    }
}

solve('Peter', 29, 75, 182);