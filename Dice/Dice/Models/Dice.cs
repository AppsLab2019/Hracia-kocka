using System;

namespace Dice.Models
{
    class Dice
    {
        public int CountOfWalls { get; }

        public Dice(int countOfWalls)
        {
            CountOfWalls = countOfWalls; 
        }

        public int Throw()
        {
            Random number = new Random();
            return number.Next(1, CountOfWalls + 1);
        }
    }
}
