namespace Travel.Entities
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Items.Contracts;

    public class Bag : IBag
    {
        private readonly List<IItem> items;

        public Bag(IPassenger owner, IEnumerable<IItem> items)
        {
            this.Owner = owner;
            this.items = items.ToList();
        }

        public IPassenger Owner { get; }

        public IReadOnlyCollection<IItem> Items => this.items.AsReadOnly();
    }
}