using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendu
{
    internal class GameInstance
    {
        private int maxErrors { get; set; }

        public List<char> Guesses { get; }

        public List<char> Misses { get; }

        public List<Word> Words { get; }
        public Word WordToGuess { get; }

        private Random rnd;

        private bool isWin { get; set; }

        private string currentWordGuessed;
    
        public GameInstance(int maxErrors = 10)
        {
            rnd = new Random();
            this.maxErrors = maxErrors;

            Words = new List<Word>
            {
                new Word("tulipe"),
                new Word("pendu"),
                new Word("craie"),
                new Word("fromage"),
                new Word("ambolie")
            };

            Guesses = new List<char>();
            Misses = new List<char>();

            WordToGuess = Words[rnd.Next(0,Words.Count)];

            Console.WriteLine("Le mot à deviner contient {0} lettres", WordToGuess.Length);

            currentWordGuessed = PrintWordToGuess();

        }

        public GameInstance(List<Word> words, int maxErrors = 10)
        {
            rnd = new Random();
            this.maxErrors = maxErrors;

            Words = words;

            Guesses = new List<char>();
            Misses = new List<char>();

            WordToGuess = Words[rnd.Next(0, Words.Count)];

            Console.WriteLine("Le mot à deviner contient {0} lettres", WordToGuess.Length);
        }

        public void Play()
        {
            while (!isWin)
            {
                Console.WriteLine("Donnez moi une lettre :");
                char letter = char.ToUpper(Console.ReadKey(true).KeyChar);
                int letterIndex = WordToGuess.GetIndexOf(letter);

                if(letterIndex != -1)
                {
                    Console.WriteLine($"Bravo, une lettre de moins a trouver : {letter}");
                    Guesses.Add(letter);
                }
                else
                {
                    Console.WriteLine($"Malheureusement il n'y a pas de : {letter}");
                    Misses.Add(letter);
                }

                if (Misses.Count > 0)
                {
                    Console.WriteLine($"Erreurs ({Misses.Count}) : {string.Join(", ", Misses)}");
                }

                currentWordGuessed = PrintWordToGuess();

                if (currentWordGuessed.IndexOf('_') == -1)
                {
                    Console.WriteLine("Félicitation, vous avez gagner !");
                    Console.ReadKey();
                }

                if (Misses.Count >= maxErrors)
                {
                    Console.WriteLine("Vous avez perdu !");
                    Console.ReadKey();
                    break;
                }
            }
        }
    
        private string PrintWordToGuess()
        {
            string currentWordGuessed = "";

            for (int i = 0; i < WordToGuess.Length; i++)
            {
                if (Guesses.Contains(WordToGuess.Text[i]))
                {
                    currentWordGuessed += WordToGuess.Text[i];
                }
                else
                {
                    currentWordGuessed += "_";
                }
            }

            Console.WriteLine(currentWordGuessed);
        
            return currentWordGuessed;
        }
    
    
    }
}
