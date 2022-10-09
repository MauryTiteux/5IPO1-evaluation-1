using System;

internal class Program
{
    static void Main(string[] args)
    {
        var random = new Random();
        var secretWord = new List<string> { "csharp", "git", "iterate", "algorithm", "debug", "object" };
        int index = random.Next(secretWord.Count);

        Pendu pendu1 = new Pendu(secretWord[index]);

        while (pendu1.IsRevealed() == false && pendu1.IsLost() == false)
        {
            Console.WriteLine("Entrez un caratère, vous avez droit à 10 erreurs");
            char input = Console.ReadKey().KeyChar; //fonction pour détecter une entrée clavier
            if (pendu1.Attempt(input))
            {
                Console.WriteLine();
                Console.WriteLine("Bravo vous avez trouvé");
            }

            Console.WriteLine();
            Console.WriteLine(pendu1);
        }
        if (pendu1.IsRevealed() == true)
        {
            Console.WriteLine();
            Console.WriteLine("Vous avez gagné, le mot était bien : " + pendu1);
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Vous avez perdu !");
        }
    }
}