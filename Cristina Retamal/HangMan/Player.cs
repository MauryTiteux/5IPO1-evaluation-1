using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangMan
{
    public class Player
    {
        private string name;
        private int lifePoints;

        public Player(string name)
        {
            this.name = name;
            resetLifePoints(); // for each new gamer
        }

        public string getName(){return name;}
        public int getLifePoints(){return lifePoints;}

        private void resetLifePoints()
        {
            this.lifePoints = 6;
        }

        private void loseLifePoints()
        {
            this.lifePoints = this.lifePoints - 1;
        }

    }
}