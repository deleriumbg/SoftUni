using System;
using DungeonsAndCodeWizards.Models.Items;

namespace DungeonsAndCodeWizards.Factories
{
    public class ItemFactory
    {
        public Item CreateItem(string type)
        {
            switch (type)
            {
                case "HealthPotion":
                    return new HealthPotion();
                case "PoisonPotion":
                    return new PoisonPotion();
                case "ArmorRepairKit":
                    return new ArmorRepairKit();
                default:
                    throw new ArgumentException($"Invalid item \"{type}\"!");
            }
        }
    }
}
