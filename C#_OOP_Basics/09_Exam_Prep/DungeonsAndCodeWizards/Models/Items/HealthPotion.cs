using DungeonsAndCodeWizards.Models.Characters;

namespace DungeonsAndCodeWizards.Models.Items
{
    public class HealthPotion : Item
    {
        private const int DefaultWeight = 5;

        public HealthPotion() : base(DefaultWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            EnsureIsAlive(character);
            character.Health += 20;
        }
    }
}
