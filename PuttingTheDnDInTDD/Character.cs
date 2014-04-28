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
        public List<Ability> Abilities { get; set; }

        public bool IsDead
        {
            get
            {
                return HitPoints <= 0;
            }
        }

        public Character()
        {
            Armor = 10;
            HitPoints = 5;
            Abilities = new List<Ability>
                {
                    new Ability("Strength"),
                    new Ability("Dexterity"),
                    new Ability("Constitution"),
                    new Ability("Wisdom"),
                    new Ability("Intelligence"),
                    new Ability("Charisma")
                };
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
