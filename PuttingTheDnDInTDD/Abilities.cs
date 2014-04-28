namespace PuttingTheDnDInTDD
{
    public class Abilities
    {
        private int _strength;
        private int _dexterity;
        private int _constitution;
        private int _wisdom;
        private int _intelligence;
        private int _charisma;

        public int Strength
        {
            get { return _strength; }
            set
            {
                if (value > 20)
                    _strength = 20;
                else if (value < 1)
                    _strength = 1;
                else
                    _strength = value;
            }
        }
        public int Dexterity
        {
            get { return _dexterity; }
            set
            {
                if (value > 20)
                    _dexterity = 20;
                else if (value < 1)
                    _dexterity = 1;
                else
                    _dexterity = value;
            }
        }
        public int Constitution
        {
            get { return _constitution; }
            set
            {
                if (value > 20)
                    _constitution = 20;
                else if (value < 1)
                    _constitution = 1;
                else
                    _constitution = value;
            }
        }
        public int Wisdom
        {
            get { return _wisdom; }
            set
            {
                if (value > 20)
                    _wisdom = 20;
                else if (value < 1)
                    _wisdom = 1;
                else
                    _wisdom = value;
            }
        }
        public int Intelligence
        {
            get { return _intelligence; }
            set
            {
                if (value > 20)
                    _intelligence = 20;
                else if (value < 1)
                    _intelligence = 1;
                else
                    _intelligence = value;
            }
        }
        public int Charisma
        {
            get { return _charisma; }
            set
            {
                if (value > 20)
                    _charisma = 20;
                else if (value < 1)
                    _charisma = 1;
                else
                    _charisma = value;
            }
        }

        public Abilities()
        {
            Strength = 10;
            Dexterity = 10;
            Constitution = 10;
            Wisdom = 10;
            Intelligence = 10;
            Charisma = 10;
        }
    }
}
