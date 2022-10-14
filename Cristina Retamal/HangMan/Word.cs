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

        public bool addLetter(char letter)
        {
            bool passed = false;
            if(this.refWord.Contains(letter))
            {
                for(int i=0; i < this.refWord.Length; i++)
                {
                    if(this.refWord[i] == letter && this.currentWord[i] == '_')
                    {
                        char[] charArr = this.currentWord.ToCharArray();
                        charArr[i] = letter; 
                        this.currentWord = new string(charArr);   
                        passed = true;

                    }
                    
                }
                
            }

            Console.WriteLine(this.currentWord);

            return passed;
        }
        
    }
}