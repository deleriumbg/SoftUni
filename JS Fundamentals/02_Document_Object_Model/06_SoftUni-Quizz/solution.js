function solve() {
    let questionNumber = 1;
    let correctAnswers = 0;

    let buttons = document.getElementsByTagName('button');
    for (let button of buttons) {
        button.addEventListener('click', answer);
    }

    function answer() {
        let questions = document.getElementsByTagName('section');
        let answer;

        for (let radioButton of questions[questionNumber - 1].getElementsByTagName('input')) {
            if (radioButton.checked) {
                answer = radioButton.value;
            }
        }

        if (questionNumber === 1) {
            if (answer === '2013') {
                correctAnswers++;
            }
            questions[questionNumber].removeAttribute('class');
        } else if (questionNumber === 2) {
            if (answer === 'Pesho') {
                correctAnswers++;
            }
            questions[questionNumber].removeAttribute('class');
        } else if (questionNumber === 3) {
            if (answer === 'Nakov') {
                correctAnswers++;
            }

            let result = document.getElementById('result');
            if (correctAnswers === 3) {
                result.textContent = 'You are recognized as top SoftUni fan!';
            } else {
                result.textContent = `You have ${correctAnswers} right answers`;
            }
        }

        questionNumber++;
    }
}