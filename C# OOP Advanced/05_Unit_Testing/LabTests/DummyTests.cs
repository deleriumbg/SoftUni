using NUnit.Framework;

namespace LabTests
{
    public class DummyTests
    {
        private const int AxeAttack = 10;
        private const int AxeDurability = 10;
        private const int DummyHealth = 50;
        private const int ExpectedHealth = 40;
        private const int DummyExperience = 10;

        [Test]
        public void DummyLosesHealthIfAttacked()
        {
            Axe axe = new Axe(AxeAttack, AxeDurability);
            Dummy dummy = new Dummy(DummyHealth, 10);
            axe.Attack(dummy);
            Assert.That(dummy.Health, Is.EqualTo(ExpectedHealth));
        }

        [Test]
        public void DeadDummyThrowsExceptionIfAttacked()
        {
            Axe axe = new Axe(AxeAttack, AxeDurability);
            Dummy dummy = new Dummy(0, DummyExperience);
            Assert.That(() => axe.Attack(dummy), Throws.InvalidOperationException);
        }

        [Test]
        public void DeadDummyCanGiveXP()
        {
            Hero hero = new Hero("Pesho", new Axe(AxeAttack, AxeDurability));
            Dummy dummy = new Dummy(10, DummyExperience);
            hero.Attack(dummy);
            Assert.That(hero.Experience, Is.EqualTo(DummyExperience));
        }

        [Test]
        public void AliveDummyCantGiveXP()
        {
            Hero hero = new Hero("Pesho", new Axe(AxeAttack, AxeDurability));
            Dummy dummy = new Dummy(DummyHealth, DummyExperience);
            hero.Attack(dummy);
            Assert.That(hero.Experience, Is.EqualTo(0));
        }
    }
}
