using System;

public class App
{
    public static void Main(string[] args)
    {
        Console.Title = "Jeu du pendu";
        Console.ReadKey();

        string[] words = new string[] {"Chouffe", "Duvel", "Triple Karmeliet", "Cornet"};
        Random random = new Random();
        var randomIndex = random.Next(0, words.Length);
        string hiddenWord = words[randomIndex];

    }
}