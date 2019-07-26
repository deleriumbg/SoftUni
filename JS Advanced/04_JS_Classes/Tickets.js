function storeTickets(tickets, sortingCriterion){
    class Ticket {
        constructor(destination, price, status){
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

    for (let i = 0; i < tickets.length; i++) {
        let [destination, price, status] = tickets[i].split('|');
        price = Number(price);

        tickets[i] = new Ticket(destination, price, status);
    }

    // sortingCriterion can be destination, price, or status
    tickets.sort((a, b) => {
        if (a[ sortingCriterion] > b[ sortingCriterion]) {
            return 1;
        }
        if (a[ sortingCriterion] < b[ sortingCriterion]) {
            return -1;
        }
    });
    return tickets;
}

console.log(storeTickets(['Philadelphia|94.20|available',
        'New York City|95.99|available',
        'New York City|95.99|sold',
        'Boston|126.20|departed'],
    'destination'
));