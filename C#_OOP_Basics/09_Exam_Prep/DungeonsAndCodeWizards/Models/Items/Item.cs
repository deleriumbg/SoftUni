using System;
using DungeonsAndCodeWizards.Models.Characters;

namespace DungeonsAndCodeWizards.Models.Items
{
    public abstract class Item
    {
        public int Weight { get; private set; }

        protected Item(int weight)
        {
            this.Weight = weight;
        }

        public abstract void AffectCharacter(Character character);

        protected void EnsureIsAlive(Character character)
        {
            if (!character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }
    }
}
