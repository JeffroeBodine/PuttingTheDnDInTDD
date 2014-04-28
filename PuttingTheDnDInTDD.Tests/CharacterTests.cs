﻿using System;
using System.Reflection;
using NUnit.Framework;

namespace PuttingTheDnDInTDD.Tests
{
    [TestFixture]
    public class CharacterTests
    {
        private Character c;

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
            c.Attack(roll);
            Assert.AreEqual(4, c.HitPoints);
        }

        [TestCase(9, 10)]
        [TestCase(19, 20)]
        public void CharacterCantHitWhenRollLessThanArmor(int roll, int armor)
        {
            c.HitPoints = 5;
            c.Armor = armor;
            c.Attack(roll);
            Assert.AreEqual(5, c.HitPoints);
        }

        [Test]
        public void CriticalHitTakesAway2HitPoints()
        {
            c.HitPoints = 5;
            c.Attack(20);
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



        [Test]
        public void AbilityIs10ThenModifierIs0()
        {
            var a = new Ability("TestAbility-BaDumBum");
            a.Value = 10;
            Assert.AreEqual(0, a.Modifier);
        }

        [Test]
        public void AbilityIs11ThenModifierIs0()
        {
            var a = new Ability("TestAbility-BaDumBum");
            a.Value = 11;
            Assert.AreEqual(0, a.Modifier);
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

    }
}
