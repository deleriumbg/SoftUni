function toggle() {
    let buttonElement = document.querySelector('#accordion > div.head > span');
    let extraDiv = document.getElementById('extra');
    if (buttonElement.textContent === 'Less') {
        extraDiv.style.display = 'none';
        buttonElement.textContent = 'More';
    } else if (buttonElement.textContent === 'More'){
        extraDiv.style.display = 'block';
        buttonElement.textContent = 'Less';
    }
}