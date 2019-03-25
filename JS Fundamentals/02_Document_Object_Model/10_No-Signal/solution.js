function solve() {
    let randomHorizontalRange = getRandomArbitrary(1, 81);
    let randomVerticalRange = getRandomArbitrary(1, 45);
    setTimeout(function () {
        document.querySelector('#exercise div').style.marginLeft = randomHorizontalRange + '%';
        document.querySelector('#exercise div').style.marginTop = randomVerticalRange + 'vh';
        solve();
    }, 2000);

    function getRandomArbitrary(min, max) {
        return Math.random() * (max - min) + min;
    }
}