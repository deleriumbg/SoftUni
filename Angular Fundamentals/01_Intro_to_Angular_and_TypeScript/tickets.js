var Ticket = /** @class */ (function () {
    function Ticket(destination, price, status) {
        this.destination = destination;
        this.price = price;
        this.status = status;
    }
    return Ticket;
}());
function sortTickets(ticketArray, sortArgument) {
    var tickets = [];
    for (var _i = 0, ticketArray_1 = ticketArray; _i < ticketArray_1.length; _i++) {
        var ticket = ticketArray_1[_i];
        var ticketInfo = ticket.split('|');
        var ticketObj = new Ticket(ticketInfo[0], Number(ticketInfo[1]), ticketInfo[2]);
        tickets.push(ticketObj);
    }
    switch (sortArgument) {
        case 'destination':
            tickets = tickets.sort(function (a, b) { return a.destination.localeCompare(b.destination); });
            break;
        case 'price':
            tickets = tickets.sort(function (a, b) { return Number(a.price) - Number(b.price); });
            break;
        case 'status':
            tickets = tickets.sort(function (a, b) { return a.status.localeCompare(b.status); });
            break;
        default:
            break;
    }
    console.log(tickets);
}
sortTickets(['Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'], 'destination');
