using System;

namespace HangMan 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenu au jeu du pendu");


            // Testing methods from class Word
            Word s = new Word("bonjour");
            Console.WriteLine(s.getCurrentWord());
            Console.WriteLine(s.addLetter('i'));

            // Testing methods from class Player
            Player p = new Player("cristina");
            Console.WriteLine(p.getName());
            Console.WriteLine(p.getLifePoints());

        
            
        }
    }
}