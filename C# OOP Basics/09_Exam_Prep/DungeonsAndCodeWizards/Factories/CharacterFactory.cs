using System;
using DungeonsAndCodeWizards.Models.Characters;

namespace DungeonsAndCodeWizards.Factories
{
    public class CharacterFactory
    {
        public Character CreateCharacter(string faction, string characterType, string name)
        {
            if (!Enum.TryParse(faction, true, out Faction parsedFaction))
            {
                throw new ArgumentException($"Invalid faction \"{faction}\"!");
            }

            switch (characterType)
            {
                case "Warrior":
                    return new Warrior(name, parsedFaction);
                case "Cleric":
                    return new Cleric(name, parsedFaction);
                default:
                    throw new ArgumentException($"Invalid character \"{characterType}\"!");

            }
        }
    }
}
