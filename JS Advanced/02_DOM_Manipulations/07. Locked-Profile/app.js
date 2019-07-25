function lockedProfile() {
    let buttons = document.getElementsByTagName('button');
    for (let button of buttons) {
        button.addEventListener('click', showOrHide);
    }

    function showOrHide(e) {
        let button = e.target;
        let profile = button.parentNode;
        let inputElements = profile.getElementsByTagName('input');
        let divElements = profile.getElementsByTagName('div');

        if (button.textContent === 'Show more' && !inputElements[0].checked) {
            button.textContent = 'Hide it';

            divElements[1].style.display = 'block';
        } else if (button.textContent === 'Hide it' && !inputElements[0].checked) {
            button.textContent = 'Show more';

            divElements[1].style.display = 'none';
        }
    }
}