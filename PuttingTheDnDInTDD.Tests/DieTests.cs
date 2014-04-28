using NUnit.Framework;

namespace PuttingTheDnDInTDD.Tests
{
    public class DieTests
    {
        [TestCase(10, 0, 10)]
        [TestCase(9, 1, 10)]
        [TestCase(5, -4, 1)]
        [TestCase(1, -5, -4)]
        [TestCase(20, 5, 25)]
        public void StrengthModifierAddedToRoll(int roll, int strengthModifier, int expected)
        {
            int ModifiedDieRoll = Die.Roll(roll, strengthModifier);
            Assert.AreEqual(expected, ModifiedDieRoll);
        }
    }
}