using System;
using NUnit.Framework;

namespace PuttingTheDnDInTDD.Tests
{
    [TestFixture]
    public class CharacterTests
    {
        [Test]
        public void CanGetAndSetCharacterName()
        {
            var c = new Character();
            c.Name = "Some Name";
            Assert.AreEqual("Some Name", c.Name);
        }

        [Test]
        public void CanGetAndSetKnownAlignmentValues([Values("Good", "Evil", "Neutral")] string input)
        {
            var c = new Character();
            c.Alignment = input;
            Assert.AreEqual(input, c.Alignment);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void UnknownAlignmentValueThrowsException()
        {
            var c = new Character();
            c.Alignment = "Awesome";
        }

        [Test]
        public void CharacterArmorDefaultsTo10()
        {
            var c = new Character();
            Assert.AreEqual(10, c.Armor);
        }

        [Test]
        public void CharacterHitPointsDefaultsTo5()
        {
            var c = new Character();
            Assert.AreEqual(5, c.HitPoints);
        }

        [TestCase(1, 1)]
        [TestCase(2, 1)]
        [TestCase(10, 10)]
        [TestCase(11, 10)]
        public void CharacterCanHitWhenRollGreaterThanOrEqualToArmor(int roll, int armor)
        {
            var c = new Character();
            c.HitPoints = 5;
            c.Armor = armor;
            c.Attack(roll);
            Assert.AreEqual(4, c.HitPoints);
        }

        [TestCase(9, 10)]
        [TestCase(19, 20)]
        public void CharacterCantHitWhenRollLessThanArmor(int roll, int armor)
        {
            var c = new Character();
            c.HitPoints = 5;
            c.Armor = armor;
            c.Attack(roll);
            Assert.AreEqual(5, c.HitPoints);
        }
    }
}
