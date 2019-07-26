function solve(selector){
    let element = document.querySelector(selector);

    (function changeClass(element){
        if (element.hasChildNodes()) {
            element.className += ' highlight';
            changeClass(Array.from(element.childNodes).sort((a,b) => b.childNodes.length - a.childNodes.length)[0]);
        }
    })(element);
}

solve('#content');