function getInfo() {
    const stopIdElement = $('#stopId');
    let stopId = stopIdElement.val();
    let url = `https://judgetests.firebaseio.com/businfo/${stopId}.json`;

    $.ajax({
        method: 'GET',
        url,
        success: handleRequest,
        error: handleError
    });

    stopIdElement.val('');

    function handleRequest(req){
        $('#buses').empty();
        $('#stopName').text(req.name);
        let ulElement = $('#buses');
        let liElement;
        for (let bus in req.buses) {
            liElement = $('<li>').text(`Bus ${bus} arrives in ${req.buses[bus]} minutes`);
            ulElement.append(liElement);
        }
    }

    function handleError(res){
        $('#buses').empty();
        $('#stopName').text('Error');
    }
}