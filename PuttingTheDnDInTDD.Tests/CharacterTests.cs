using System;
using System.Reflection;
using NUnit.Framework;

namespace PuttingTheDnDInTDD.Tests
{
    [TestFixture]
    public class CharacterTests
    {
        private Character c;
        private readonly DieTests _dieTests = new DieTests();

        [SetUp]
        public void BeforeEach()
        {
            c = new Character();
        }

        public void SetAllAbilityValues(int val)
        {
            foreach (var ability in c.Abilities)
            {
                ability.Value = val;
            }
        }

        [Test]
        public void CanGetAndSetCharacterName()
        {
            c.Name = "Some Name";
            Assert.AreEqual("Some Name", c.Name);
        }

        [Test]
        public void CanGetAndSetKnownAlignmentValues([Values("Good", "Evil", "Neutral")] string input)
        {
            c.Alignment = input;
            Assert.AreEqual(input, c.Alignment);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void UnknownAlignmentValueThrowsException()
        {
            c.Alignment = "Awesome";
        }

        [Test]
        public void CharacterArmorDefaultsTo10()
        {
            Assert.AreEqual(10, c.Armor);
        }

        [Test]
        public void CharacterHitPointsDefaultsTo5()
        {
            Assert.AreEqual(5, c.HitPoints);
        }

        [TestCase(1, 1)]
        [TestCase(2, 1)]
        [TestCase(10, 10)]
        [TestCase(11, 10)]
        public void CharacterCanHitWhenRollGreaterThanOrEqualToArmor(int roll, int armor)
        {
            c.HitPoints = 5;
            c.Armor = armor;
            c.Attack(roll, false, 0);
            Assert.AreEqual(4, c.HitPoints);
        }

        [TestCase(9, 10)]
        [TestCase(19, 20)]
        public void CharacterCantHitWhenRollLessThanArmor(int roll, int armor)
        {
            c.HitPoints = 5;
            c.Armor = armor;
            c.Attack(roll, false, 0);
            Assert.AreEqual(5, c.HitPoints);
        }

        [Test]
        public void CriticalHitTakesAway2HitPoints()
        {
            c.HitPoints = 5;
            c.Attack(20, true, 0);
            Assert.AreEqual(3, c.HitPoints);
        }

        [Test]
        public void CharacterIsDeadIfHitPointsEqual0([Values(0, -1)] int input)
        {
            c.HitPoints = input;
            Assert.AreEqual(true, c.IsDead);
        }

        [Test]
        public void CharacterIsAliveIfHitPointsGreaterThan0([Values(1, 2)] int input)
        {
            c.HitPoints = input;
            Assert.AreEqual(false, c.IsDead);
        }

        [Test]
        public void CharacterHasAbilitiesWithDefaults()
        {
            AssertAbilityValues(10);
        }

        [Test]
        public void CharacterAbilitiesCantBeGreaterThan20()
        {
            SetAllAbilityValues(21);
            AssertAbilityValues(20);
        }

        [Test]
        public void CharacterAbilitiesCantBeLessThan1()
        {
            SetAllAbilityValues(0);
            AssertAbilityValues(1);
        }

        public void AssertAbilityValues(int expected)
        {
            foreach (var ability in c.Abilities)
            {
                Assert.AreEqual(expected, ability.Value);
            }
        }

        [TestCase(1, -5)]
        [TestCase(8, -1)]
        [TestCase(9, -1)]
        [TestCase(10, 0)]
        [TestCase(11, 0)]
        [TestCase(12, 1)]
        [TestCase(13, 1)]
        [TestCase(20, 5)]
        public void AbilityValueSetsModifier(int value, int modifier)
        {
            var a = new Ability("TestAbility-BaDumBum");
            a.Value = value;

            Assert.AreEqual(modifier, a.Modifier);
        }

        [TestCase(10, 0, 4)]
        [TestCase(25, 5, -1)]
        public void StrengthModifierAddedToAttack(int modifiedRoll, int strengthModifier, int expected)
        {
            c.HitPoints = 5;
            c.Armor = int.MinValue;
            c.Attack(modifiedRoll, false, strengthModifier);
            Assert.AreEqual(expected, c.HitPoints);
        }

        [TestCase(25, 5, -7)]
        public void DoubledStrengthModifierAddedToAttackWhenRoll20(int modifiedRoll, int strengthModifier, int expected)
        {
            c.HitPoints = 5;
            c.Armor = int.MinValue;
            c.Attack(modifiedRoll, true, strengthModifier);
            Assert.AreEqual(expected, c.HitPoints);
        }

        [TestCase(-4, -5, 4)]
        [TestCase(0, -1, 4)]
        public void MinimumDamageIs1(int modifiedRoll, int strengthModifier, int expected)
        {
            c.HitPoints = 5;
            c.Armor = int.MinValue;
            c.Attack(modifiedRoll, false, strengthModifier);
            Assert.AreEqual(expected, c.HitPoints);
        }

        [TestCase(15, -5, 4)]
        public void MinimumDamageIs1WithCriticalHit(int modifiedRoll, int strengthModifier, int expected)
        {
            c.HitPoints = 5;
            c.Armor = int.MinValue;
            c.Attack(modifiedRoll, true, strengthModifier);
            Assert.AreEqual(expected, c.HitPoints);
        }
    }
}
