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

        public Character()
        {
            Armor = 10;
            HitPoints = 5;
        }

        public bool Attack(int roll)
        {
            if (roll >= Armor)
                return true;

            return false;
        }
    }
}
