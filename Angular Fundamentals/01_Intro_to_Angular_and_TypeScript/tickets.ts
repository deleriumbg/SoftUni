class Ticket {
    private destination: string;
    private price: number;
    private status: string;

    constructor(destination: string, price: number, status: string) {
        this.destination = destination;
        this.price = price;
        this.status = status;
    }
}

function sortTickets(ticketArray, sortArgument) {
    let tickets = [];
    for (const ticket of ticketArray) {
        let ticketInfo = ticket.split('|');
        let ticketObj = new Ticket(ticketInfo[0], Number(ticketInfo[1]), ticketInfo[2]);
        tickets.push(ticketObj);
    }

    switch (sortArgument) {
        case 'destination':
            tickets = tickets.sort((a, b) => a.destination.localeCompare(b.destination));
            break;
        case 'price':
            tickets = tickets.sort((a, b) => Number(a.price) - Number(b.price));
            break;
        case 'status':
            tickets = tickets.sort((a, b) => a.status.localeCompare(b.status));
            break;
        default:
            break;
    }
    console.log(tickets);
}

sortTickets(['Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'],
    'destination'
);