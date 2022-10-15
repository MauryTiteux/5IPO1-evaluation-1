using System.Text;

public class App
{
    public static void Main()
    {
        //Mot choisit au hasard parmi une liste
        string[] words = new string[] {"chouffe", "duvel", "triple karmeliet", "orval", "barbar"};
        string response = "";
        int score = 6;
        bool win = false;
        Random random = new Random();
        var randomIndex = random.Next(0, words.Length);
        string hiddenWord = words[randomIndex];

        //Creation de la response cachée par des underscores
        for(var i=0 ; i<hiddenWord.Length ; i++)
        {
            if(Char.IsWhiteSpace(hiddenWord[i]))
            {
                response += " ";
            }
            else 
            {
                response += "_";
            }
        }

        //Verification si la lettre est presente dans le mot
        while(score != 0)
        {
            bool toggle = false;
            Console.WriteLine("Tentatives restantes : " + score);
            Console.WriteLine(response + "\n");
            Console.WriteLine("Quelle lettre ?");
            string str = Console.ReadLine();
            char userInput = char.Parse(str);

            for(var i=0 ; i<hiddenWord.Length ; i++)
            {         
                if(userInput == response[i])
                {
                    continue;
                }       
                if(hiddenWord[i] == userInput)
                {
                    toggle = true;
                    StringBuilder temp = new StringBuilder(response);
                    temp[i] = userInput;
                    response = temp.ToString();
                    break;
                }
            }
            //Checks si le mot est trouvé
            if(hiddenWord == response)
            {
                win = true;
                break;
            }
            //Sinon résultat d'un essai
            else if(toggle)
            {
                Console.WriteLine("Bien joué");
            }
            else 
            {
                Console.WriteLine("Raté !");
                score--;
            } 
        } 
        if(win)
        {
        Console.WriteLine("Vous avez trouvé le mot !\n" + response);
        }
        else
        {
            Console.WriteLine("Game Over");
        }
    }
}