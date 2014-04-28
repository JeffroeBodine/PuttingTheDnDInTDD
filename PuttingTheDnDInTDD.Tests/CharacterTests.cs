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
            c.Name = "Some Name" ;
            Assert.AreEqual("Some Name", c.Name);
        }

        [Test]
        public void CanGetAndSetKnownAlignmentValues( [Values("Good", "Evil", "Neutral")] string input)
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
        public void CharacterCantHitWithRollOf9()
        {
            var roll = 9;
            var c = new Character();
            c.Attack(roll);
            Assert.AreEqual(10, c.Armor);
        }
        
        [Test]
        public void CharacterCanHitWithRollOf10()
        {
            var roll = 10;
            var c = new Character();
            c.Attack(roll);
            Assert.AreEqual(5, c.Armor);
        }

        [Test]
        public void CharacterCanHitWithRollOf11()
        {
            var roll = 11;
            var c = new Character();
            c.Attack(roll);
            Assert.AreEqual(5, c.Armor);
        }
    }
}
