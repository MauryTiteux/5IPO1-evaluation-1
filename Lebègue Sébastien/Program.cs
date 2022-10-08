using System;

public class App
{
    public static void Main(string[] args)
    {
        Console.Title = "Jeu du pendu";
        Console.ReadKey(true);

        string hiddenWord = "Chouffe";
        bool check = false;
        string response = "";

        while (check != true)
        {
           Console.WriteLine("Entrez une lettre : ");
           response = Console.ReadLine();

           for(var i = 0 ; i<=hiddenWord.Length ; i++)
           {
            if (response = hiddenWord[i])
            {
                Console.Write("Bonne lettre : " + response);
            }
           }
           check = false ;
        }
    }
}