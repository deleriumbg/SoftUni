function capitalCaseWords (arr){
    let text = arr.join('','');
    let words = text.split(/\W+/);
    let nonEmptyWords = words.filter(w => w.length > 0);
    let upWords = nonEmptyWords.filter(isUppercase);
    console.log(upWords.join(", "));
    function isUppercase(str) {
        return str === str.toUpperCase();
    }
}

capitalCaseWords(
    ['We start by HTML, CSS, JavaScript, JSON and REST.']
)