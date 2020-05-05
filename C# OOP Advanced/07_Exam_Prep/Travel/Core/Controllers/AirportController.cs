using Travel.Entities.Items;
using Travel.Entities.Items.Contracts;

namespace Travel.Core.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Entities;
    using Entities.Contracts;
    using Entities.Factories;
    using Entities.Factories.Contracts;

    public class AirportController : IAirportController
    {
        private const int BagValueConfiscationThreshold = 3000;

        private readonly IAirport airport;
        private readonly IAirplaneFactory airplaneFactory;
        private readonly IItemFactory itemFactory;

        public AirportController(IAirport airport)
        {
            this.airport = airport;
            this.airplaneFactory = new AirplaneFactory();
            this.itemFactory = new ItemFactory();
        }

        public string RegisterPassenger(string username)
        {
            if (this.airport.GetPassenger(username) != null)
            {
                throw new InvalidOperationException($"Passenger {username} already registered!");
            }

            var passenger = new Passenger(username);
            this.airport.AddPassenger(passenger);
            return $"Registered {passenger.Username}";
        }

        public string RegisterTrip(string source, string destination, string planeType)
        {
            var airplane = this.airplaneFactory.CreateAirplane(planeType);
            var trip = new Trip(source, destination, airplane);
            this.airport.AddTrip(trip);

            return $"Registered trip {trip.Id}";
        }

        public string RegisterBag(string username, IEnumerable<string> bagItems)
        {
            var passenger = this.airport.GetPassenger(username);

            var items = bagItems.Select(itemType => this.itemFactory.CreateItem(itemType)).ToArray();
            var bag = new Bag(passenger, items);
            passenger.Bags.Add(bag);

            return $"Registered bag with {string.Join(", ", bagItems)} for {username}";
        }

        public string CheckIn(string username, string tripId, IEnumerable<int> bagIndices)
        {
            var passenger = this.airport.GetPassenger(username);
            var trip = this.airport.GetTrip(tripId);

            var checkedIn = trip.Airplane.Passengers.Any(p => p.Username == username);
            if (checkedIn)
            {
                throw new InvalidOperationException($"{username} is already checked in!");
            }

            var confiscatedBags = CheckInBags(passenger, bagIndices);
            trip.Airplane.AddPassenger(passenger);

            return
                $"Checked in {passenger.Username} with {bagIndices.Count() - confiscatedBags}/{bagIndices.Count()} checked in bags";
        }

        private int CheckInBags(IPassenger passenger, IEnumerable<int> bagsToCheckIn)
        {
            var bags = passenger.Bags;

            var confiscatedBagCount = 0;
            foreach (var bag in bagsToCheckIn)
            {
                var currentBag = bags[bag];
                bags.RemoveAt(bag);

                if (ShouldConfiscate(currentBag))
                {
                    airport.AddConfiscatedBag(currentBag);
                    confiscatedBagCount++;
                }
                else
                {
                    this.airport.AddCheckedBag(currentBag);
                }
            }

            return confiscatedBagCount;
        }

        private static bool ShouldConfiscate(IBag bag)
        {
            var luggageValue = 0;

            for (int i = 0; i < bag.Items.Count; i++)
            {
                luggageValue += bag.Items.ToArray()[i].Value;
            }

            var shouldConfiscate = luggageValue > BagValueConfiscationThreshold;
            return shouldConfiscate;
        }
    }
}