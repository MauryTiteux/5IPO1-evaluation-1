using System;

namespace HangMan 
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenu au jeu du pendu");


            Word s = new Word("bonjour");
            //Console.WriteLine(s.getCurrentWord());
            //Console.WriteLine(s.addLetter('i'));


            Player p = new Player("cristina");
            //Console.WriteLine(p.getName());
            //Console.WriteLine(p.getLifePoints());


            Game game = new Game(p, s);
            bool win = playGame(game);
            //Console.WriteLine(game.getPlayer().getName()); 
            Console.WriteLine(win);
                
            
        }

        public static bool playGame(Game game)
        {
            while(!game.hasFinished())
            {
                Console.Write("Enter a letter: ");
                char letter = (Console.ReadLine())[0];
                game.PlayTurn(letter);
                Console.WriteLine(game.getWord().getCurrentWord());
                Console.WriteLine(game.getPlayer().getLifePoints());
            }
            return game.hasWon();
        }




    }
}