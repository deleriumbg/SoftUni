using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Models.Bags;
using DungeonsAndCodeWizards.Models.Characters.Contracts;

namespace DungeonsAndCodeWizards.Models.Characters
{
    public class Cleric : Character, IHealable
    {
        private const double BaseHealth = 50;
        private const double BaseArmor = 25;
        private const double BaseAbilityPoints = 40;

        public Cleric(string name, Faction faction) : base(name, BaseHealth, BaseArmor, BaseAbilityPoints, new Backpack(), faction)
        {
        }

        public override double RestHealMultiplier => 0.5;

        public void Heal(Character character)
        {
            EnsureBothCharactersAreAlive(character);

            if (this.Faction != character.Faction)
            {
                throw new InvalidOperationException("Cannot heal enemy character!");
            }

            character.Health += this.AbilityPoints;
        }
    }
}
