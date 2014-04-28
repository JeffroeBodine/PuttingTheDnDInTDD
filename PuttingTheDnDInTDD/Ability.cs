using System;

namespace PuttingTheDnDInTDD
{
    public class Ability
    {
        private int _value ;
     
        public string Name { get; set; }
        public int Value
        {
            get { return _value; }
            set
            {
                if (value > 20)
                    _value = 20;
                else if (value < 1)
                    _value = 1;
                else
                    _value = value;
            }
        }
        public int Modifier
        {
            get
            {
                var mod = Value % 2 * -1;
                return (Value + mod - 10) / 2;
            }
        }

        public Ability(string name)
        {
            Name = name;
            Value = 10;
        }
    }
}
