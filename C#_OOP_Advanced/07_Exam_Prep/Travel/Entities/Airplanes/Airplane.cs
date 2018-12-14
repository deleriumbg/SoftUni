using Travel.Entities.Airplanes.Contracts;

namespace Travel.Entities.Airplanes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Entities.Contracts;

    public abstract class Airplane : IAirplane
    {
        private readonly List<IBag> baggageCompartment;
        private readonly List<IPassenger> passengers;

        protected Airplane(int seats, int baggageCompartments)
        {
            this.Seats = seats;
            this.BaggageCompartments = baggageCompartments;
            this.baggageCompartment = new List<IBag>();
            this.passengers = new List<IPassenger>();
        }

        public int BaggageCompartments { get; }
        public int Seats { get; }
        public bool IsOverbooked => this.Passengers.Count > this.Seats;

        public IReadOnlyCollection<IBag> BaggageCompartment => this.baggageCompartment.AsReadOnly();
        public IReadOnlyCollection<IPassenger> Passengers => this.passengers.AsReadOnly();

        public void AddPassenger(IPassenger passenger) => this.passengers.Add(passenger);

        public IPassenger RemovePassenger(int seat)
        {
            var passenger = this.passengers[seat];
            this.passengers.RemoveAt(seat);
            return passenger;
        }

        public IEnumerable<IBag> EjectPassengerBags(IPassenger passenger)
        {
            List<IBag> bags = this.baggageCompartment.Where(p => p.Owner.Username == passenger.Username).ToList();
            this.baggageCompartment.RemoveAll(p => p.Owner.Username == passenger.Username);
            return bags;
        }

        public void LoadBag(IBag bag)
        {
            if (this.BaggageCompartment.Count > this.BaggageCompartments)
            {
                throw new InvalidOperationException($"No more bag room in {this.GetType().Name}!");
            }
            this.baggageCompartment.Add(bag);
        }
    }
}