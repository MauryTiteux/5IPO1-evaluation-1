using System;

public class App
{
    public static void Main(string[] args)
    {
        //Mot choisit au hasard parmi une liste
        
        string[] words = new string[] {"chouffe", "duvel", "triple karmeliet", "orval", "barbar"};
        string response = "";
        int score = 6;
        string updatedResponse = "";
        Random random = new Random();
        var randomIndex = random.Next(0, words.Length);
        string hiddenWord = words[randomIndex];

        //Creation de la reponse avec le mot caché
        for(var i=0 ; i<hiddenWord.Length ; i++)
        {
            if(Char.IsWhiteSpace(hiddenWord[i]))
            {
                response += " .";
            }
            else 
            {
                response += "_.";
            }
        }

        //Verification si la lettre est presente dans le mot
        while(updatedResponse != hiddenWord)
        {
           if(score == 0)
            {
                Console.WriteLine("Tentatives restantes : " + score);
                Console.WriteLine("Game Over");
                break;
            }

            bool toggle = false;
            Console.WriteLine("Tentatives restantes : " + score);
            Console.WriteLine(updatedResponse + "\n");
            Console.WriteLine("Quelle lettre ?");
            string str = Console.ReadLine();
            char user = char.Parse(str);

            for(var i=0 ; i<hiddenWord.Length ; i++)
            {
                if(hiddenWord[i] == user)
                {
                   toggle = true;
                   updatedResponse = response.Replace(response[i], user);
                   break;
                }
            }

            if(toggle)
            {
                Console.WriteLine("Bien joué");
                Console.WriteLine(updatedResponse);
            }
            else 
            {
                Console.WriteLine("Raté !");
                score--;
            } 
        }
        Console.WriteLine("Bien joué ! Le mot final etait : " + updatedResponse);
    }
}