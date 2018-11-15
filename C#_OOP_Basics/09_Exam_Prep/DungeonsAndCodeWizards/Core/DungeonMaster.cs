using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DungeonsAndCodeWizards.Factories;
using DungeonsAndCodeWizards.Models.Characters;
using DungeonsAndCodeWizards.Models.Items;

namespace DungeonsAndCodeWizards.Core
{
    public class DungeonMaster
    {
        private readonly CharacterFactory characterFactory;
        private readonly ItemFactory itemFactory;
        private List<Character> characters;
        private List<Item> items;
        private int lastSurvivorRounds;

        public DungeonMaster()
        {
            this.characterFactory = new CharacterFactory();
            this.itemFactory = new ItemFactory();
            this.characters = new List<Character>();
            this.items = new List<Item>();
        }

        public string JoinParty(string[] args)
        {
            string faction = args[0];
            string characterType = args[1];
            string name = args[2];
            Character character = this.characterFactory.CreateCharacter(faction, characterType, name);
            this.characters.Add(character);
            return $"{name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];
            Item item = this.itemFactory.CreateItem(itemName);
            this.items.Add(item);
            return $"{itemName} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];
            Character character = GetCharacter(characterName);

            if (this.items.Count == 0)
            {
                throw new InvalidOperationException("No items left in pool!");
            }

            Item item = this.items.Last();
            character.Bag.AddItem(item);
            this.items.Remove(item);
            return $"{characterName} picked up {item.GetType().Name}!";
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            Character character = GetCharacter(characterName);
            Item item = character.Bag.GetItem(itemName);
            character.UseItem(item);
            return $"{character.Name} used {itemName}.";
        }

        public string UseItemOn(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            Character giver = GetCharacter(giverName);
            Character receiver = GetCharacter(receiverName);

            Item item = giver.Bag.GetItem(itemName);
            giver.UseItemOn(item, receiver);

            return $"{giverName} used {itemName} on {receiverName}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            Character giver = GetCharacter(giverName);
            Character receiver = GetCharacter(receiverName);

            Item item = giver.Bag.GetItem(itemName);
            receiver.ReceiveItem(item);

            return $"{giverName} gave {receiverName} {itemName}.";
        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var c in this.characters.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health))
            {
                sb.AppendLine($"{c.Name} - HP: {c.Health}/{c.BaseHealth}, AP: {c.Armor}/{c.BaseArmor}, Status: {(c.IsAlive ? "Alive": "Dead")}");
            }

            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            string attackerName = args[0];
            string receiverName = args[1];

            Character attacker = GetCharacter(attackerName);
            Character receiver = GetCharacter(receiverName);
            if (attacker is Cleric)
            {
                throw new ArgumentException($"{attacker.Name} cannot attack!");
            }
            ((Warrior)attacker).Attack(receiver);

            sb.AppendLine(
                $"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");

            if (!receiver.IsAlive)
            {
                sb.AppendLine($"{receiver.Name} is dead!");
            }

            return sb.ToString().TrimEnd();
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];

            Character healer = GetCharacter(healerName);
            Character receiver = GetCharacter(healingReceiverName);
            if (healer is Warrior)
            {
                throw new ArgumentException($"{healer.Name} cannot heal!");
            }
            ((Cleric)healer).Heal(receiver);

            return
                $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";
        }

        public string EndTurn()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var character in characters.Where(x => x.IsAlive))
            {
                var healthBefore = character.Health;
                character.Rest();
                sb.AppendLine($"{character.Name} rests ({healthBefore} => {character.Health})");
            }

            if (characters.Count(x => x.IsAlive) <= 1)
            {
                lastSurvivorRounds++;
            }

            return sb.ToString().TrimEnd();
        }

        public bool IsGameOver()
        {
            return lastSurvivorRounds > 1;
        }

        private Character GetCharacter(string characterName)
        {
            var character = this.characters.FirstOrDefault(x => x.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            return character;
        }
    }
}
