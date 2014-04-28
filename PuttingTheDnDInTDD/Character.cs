using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PuttingTheDnDInTDD
{
    public class Character
    {
        private string _alignment;

        public string Name { get; set; }
        public string Alignment
        {
            get { return _alignment; }
            set
            {
                var validAlignments = new List<string>() { "Good", "Evil", "Neutral" };
                if (validAlignments.Contains(value))
                {
                    _alignment = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }
        public int Armor { get; set; }
        public int HitPoints { get; set; }

        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Wisdom { get; set; }
        public int Intelligence { get; set; }
        public int Charisma { get; set; }

        public bool IsDead
        {
            get
            {
                bool ded =false;

                if (HitPoints <= 0)
                {
                    ded = true;
                }
                return ded;
            }
        }

        public Character()
        {
            Armor = 10;
            HitPoints = 5;

            Strength = 10;
            Dexterity = 10;
            Constitution = 10;
            Wisdom = 10;
            Intelligence = 10;
            Charisma = 10;

        }

        public void Attack(int roll)
        {
            if (roll >= Armor)
                HitPoints--;

            if (roll == 20)
                HitPoints--;
        }
    }
}
