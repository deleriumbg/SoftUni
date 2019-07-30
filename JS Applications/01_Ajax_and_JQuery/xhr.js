function loadRepos() {
    let req = new XMLHttpRequest();
    req.onreadystatechange = function() {
        if (req.status === 200 && req.readyState === 4){
            document.getElementById('res').textContent = req.responseText;
        }
    };
    req.open("GET", "https://api.github.com/users/testnakov/repos");
    req.send();
}