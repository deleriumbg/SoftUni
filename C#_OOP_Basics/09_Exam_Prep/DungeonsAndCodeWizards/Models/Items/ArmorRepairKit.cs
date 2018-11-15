using DungeonsAndCodeWizards.Models.Characters;

namespace DungeonsAndCodeWizards.Models.Items
{
    public class ArmorRepairKit : Item
    {
        private const int DefaultWeight = 10;

        public ArmorRepairKit() : base(DefaultWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            EnsureIsAlive(character);
            character.Armor = character.BaseArmor;
        }
    }
}
