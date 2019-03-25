function solve() {
    let buttons = document.querySelectorAll('button');
    let nextBtn = buttons[0];
    let cancelBtn = buttons[1];
    let currentStep = 1;

    nextBtn.addEventListener('click', function () {
        if (currentStep === 1) {
            document.querySelector('#content').style.backgroundImage = 'none';
            document.getElementById('firstStep').style.display = 'block';
        } else if (currentStep === 2) {
            let agreement = document.getElementsByTagName('input');
            if (agreement[0].checked) {
                document.getElementById('firstStep').style.display = 'none';
                document.getElementById('secondStep').style.display = 'block';
                document.querySelectorAll('button')[0].style.display = 'none';
                setTimeout(function () {
                    document.querySelectorAll('button')[0].style.display = 'inline-block';
                }, 3000);
            } else {
                currentStep--;
            }
        } else {
            document.getElementById('secondStep').style.display = 'none';
            document.getElementById('thirdStep').style.display = 'block';
            document.querySelectorAll('button')[0].style.display = 'none';
            document.querySelectorAll('button')[1].textContent = 'Finish';
        }
        currentStep++;
    });

    cancelBtn.addEventListener('click', function () {
        document.querySelector('section').style.display = 'none';
    });
}