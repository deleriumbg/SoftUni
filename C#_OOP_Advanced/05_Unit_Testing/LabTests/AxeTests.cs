using NUnit.Framework;

namespace LabTests
{
    public class AxeTests
    {
        private const int AxeAttack = 10;
        private const int AxeDurability = 30;
        private const int ExpectedDurability = 29;
        private const int DummyHealth = 50;
        private const int DummyExperience = 10;

        [Test]
        public void AxeLosesDurabilityAfterAttack()
        {
            Axe axe = new Axe(AxeAttack, AxeDurability);
            Dummy dummy = new Dummy(DummyHealth, DummyExperience);
            axe.Attack(dummy);
            Assert.That(axe.DurabilityPoints, Is.EqualTo(ExpectedDurability));
        }

        [Test]
        public void AttackingWithBrokenAxeThrowsException()
        {
            Axe axe = new Axe(AxeAttack, 0);
            Dummy dummy = new Dummy(DummyHealth, DummyExperience);
            Assert.That(() => axe.Attack(dummy), Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
        }
    }
}
