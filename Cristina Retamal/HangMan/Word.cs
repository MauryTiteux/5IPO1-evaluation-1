using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangMan
{
    public class Word
    {
        private string refWord;
        private string currentWord;

        public Word(string refWord)
        {
            this.refWord = refWord;
            this.currentWord = new String('_', refWord.Length);
        }

        public string getCurrentWord(){return currentWord;}

        public bool isFound()
        {
            return this.refWord == this.currentWord;

        }

        

        
    }
}