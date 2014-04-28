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

        [Test]
        public void CharacterCantHitWWhenRollIsLessThanDefaultArmor()
        {
            var roll = 9;
            var armor = 10;
            var c = new Character();
            c.Armor = armor;
            var hit = c.Attack(roll);
            Assert.AreEqual(false, hit);
        }

        [Test]
        public void CharacterCanHitWhenRollIsEqualToDefaultArmor()
        {
            var roll = 10;
            var armor = 10;
            var c = new Character();
            c.Armor = armor;
            var hit = c.Attack(roll);
            Assert.AreEqual(true, hit);
        }

        [Test]
        public void CharacterCanHitWhenRollIsGreaterThanDefaultArmor()
        {
            var roll = 11;
            var armor = 10;
            var c = new Character();
            c.Armor = armor;
            var hit = c.Attack(roll);
            Assert.AreEqual(true, hit);
        }

        [Test]
        public void CharacterCantHitWWhenRollIsLessThanArmor()
        {
            var roll = 19;
            var armor = 20;
            var c = new Character();
            c.Armor = armor;
            var hit = c.Attack(roll);
            Assert.AreEqual(false, hit);
        }

        [Test]
        public void CharacterCanHitWhenRollIsEqualToArmor()
        {
            var roll = 1;
            var armor = 1;
            var c = new Character();
            c.Armor = armor;
            var hit = c.Attack(roll);
            Assert.AreEqual(true, hit);
        }

        [Test]
        public void CharacterCanHitWhenRollIsGreaterThanArmor()
        {
            var roll = 2;
            var armor = 1;
            var c = new Character();
            c.Armor = armor;
            var hit = c.Attack(roll);
            Assert.AreEqual(true, hit);
        }

        [TestCase(1, 1)]
        [TestCase(2, 1)]
        [TestCase(10, 10)]
        [TestCase(11, 10)]
        public void CharacterCanHitWhenRollGreaterThanOrEqualToArmor(int roll, int armor)
        {
            var c = new Character();
            c.Armor = armor;
            var hit = c.Attack(roll);
            Assert.AreEqual(true, hit);
        }

        [TestCase(9, 10)]
        [TestCase(19, 20)]
        public void CharacterCantHitWhenRollLessThanArmor(int roll, int armor)
        {
            var c = new Character();
            c.Armor = armor;
            var hit = c.Attack(roll);
            Assert.AreEqual(false, hit);
        }
    }
}
