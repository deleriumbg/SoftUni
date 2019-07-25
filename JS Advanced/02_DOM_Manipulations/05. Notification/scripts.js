function notify(message) {
    let notificationElement = document.getElementById('notification');
    notificationElement.innerHTML = message;
    notificationElement.style.display = 'block';

    setTimeout(function(){
        notificationElement.style.display = 'none';
    }, 2000)
}