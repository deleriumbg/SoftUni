function solve() {
    let nextStopId = 'depot';
    let stopName = '';

    function depart(){
        $('#depart').attr('disabled', true);
        $.ajax({
            method: 'GET',
            url: `https://judgetests.firebaseio.com/schedule/${nextStopId}.json`,
            success: handleRequest,
            error: handleError
        });

        function handleRequest(req){
            $('#info').text(`Next stop ${req.name}`);
            nextStopId = req.next;
            stopName = req.name;
            $('#arrive').attr('disabled', false);
        }

        function handleError(res){
            $('#info').text('Error');
            $('#arrive').attr('disabled', true);
        }
    }

    function arrive(){
        $('#arrive').attr('disabled', true);
        $('#info').text(`Arriving at ${stopName}`);
        $('#depart').attr('disabled', false);
    }

    return {
        depart,
        arrive
    };
}
let result = solve();