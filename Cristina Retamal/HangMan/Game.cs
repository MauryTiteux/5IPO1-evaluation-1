using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangMan
{
    public class Game
    {
        private Player player;
        private Word word;

        public Game(Player player, Word word)
        {
            this.player = player;
            this.word = word;

        }

        public Player getPlayer(){return player;}
        public Word getWord(){return word;}

        public void PlayTurn(char letter)
        {
            bool letterAdded = this.word.addLetter(letter);
            if(!letterAdded)
            {
                this.player.loseLifePoints();
            }
        }

        public bool hasFinished()
        {
            if(this.player.getLifePoints() == 0)
            {
                return true;
            }
            if(this.word.isFound())
            {
                return true;
            }
            return false;
        }

        public bool hasWon()
        {
            if(this.word.isFound() && this.player.getLifePoints() >0)
            {
                return true;

            }
            return false;
        }






    }
}