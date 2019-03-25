function solve() {
    let button = document.getElementById('searchBtn');
    let table = Array.from(document.querySelectorAll('tbody tr'));

    button.addEventListener('click', search);

    function search() {
        table.forEach((tr) => {
            tr.removeAttribute('class')
        });
        for (let tr of table) {
            let input = document.getElementById('searchField').value;
            if (tr.textContent.toLowerCase().includes(input)) {
                tr.setAttribute('class', 'select');
            }
        }
        document.getElementById('searchField').value = '';
    }
}
