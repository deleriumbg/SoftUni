using System;
using DungeonsAndCodeWizards.Models.Bags;
using DungeonsAndCodeWizards.Models.Items;

namespace DungeonsAndCodeWizards.Models.Characters
{
    public abstract class Character
    {
        private const double DefaultRestHealMultiplier = 0.2;
        private string name;
        private double health;
        private double armor;

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = health;
            this.BaseArmor = armor;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Faction = faction;
            this.IsAlive = true;
            this.RestHealMultiplier = DefaultRestHealMultiplier;
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                name = value;
            }
        }

        public double BaseHealth { get; private set; }

        public double Health
        {
            get
            {
                return this.health;
            }
            set
            {
                if (value > this.BaseHealth)
                {
                    this.health = this.BaseHealth;
                }
                else if (value <= 0)
                {
                    this.health = 0;
                    this.IsAlive = false;
                }
                else
                {
                    this.health = value;
                }
            }
        }

        public double BaseArmor { get; private set; }

        public double Armor
        {
            get
            {
                return this.armor;
            }
            set
            {
                if (value > this.BaseArmor)
                {
                    this.armor = this.BaseArmor;
                }
                else if (value < 0)
                {
                    this.armor = 0;
                }
                else
                {
                    this.armor = value;
                }
            }
        }

        public double AbilityPoints { get; private set; }

        public Bag Bag { get; private set; }

        public Faction Faction { get; private set; }

        public bool IsAlive { get; set; }

        public virtual double RestHealMultiplier { get; private set; }

        public void TakeDamage(double hitPoints)
        {
            EnsureIsAlive();
            if (this.Armor - hitPoints >= 0)
            {
                this.Armor -= hitPoints;
            }
            else
            {
                double remainder = hitPoints - this.Armor;
                this.Armor = 0;
                this.Health -= remainder;
            }
        }

        private void EnsureIsAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }

        protected void EnsureBothCharactersAreAlive(Character character)
        {
            if (!this.IsAlive || !character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }

        public void Rest()
        {
            EnsureIsAlive();
            this.Health += this.BaseHealth * this.RestHealMultiplier;
        }

        public void UseItem(Item item)
        {
            EnsureIsAlive();
            item.AffectCharacter(this);
        }

        public void UseItemOn(Item item, Character character)
        {
            EnsureBothCharactersAreAlive(character);
            item.AffectCharacter(character);
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            EnsureBothCharactersAreAlive(character);
            character.ReceiveItem(item);
        }

        public void ReceiveItem(Item item)
        {
            EnsureIsAlive();
            this.Bag.AddItem(item);
        }
    }
}
