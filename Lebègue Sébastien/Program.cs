using System.Text;

namespace HangMan
{
    public class Game
    {
        //Déclaration des variables publiques
        public string[] words;
        public string response;
        public int score;
        public bool win;
        public Random random;
        public int randomIndex;
        public string hiddenWord;
        public bool toggle;
        public string str;
        public char userInput;
        public StringBuilder temp;

        //Création de la lise de mots du pendu
        public void WordList()
        {
            words = new string[] {"chouffe", "duvel", "triple karmeliet", "orval", "barbar"};
        }
        //Choix du mot au hasard
        public void RandomWord()
        {
            random = new Random();
            randomIndex = random.Next(0, words.Length);
            hiddenWord = words[randomIndex];
        }
        //Création du visuel du mot caché
        public void HideWord()
        {
            for(int i=0 ; i<hiddenWord.Length ; i++)
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
        }
        //Verification si la lettre est presente dans le mot
        public void CheckAnswer()
        {
            score = 6;
            toggle = false;
            win = false;

            while(score != 0)
            {
                toggle = false;
                Console.WriteLine("Tentatives restantes : " + score);
                Console.WriteLine(response + "\n");
                Console.WriteLine("Quelle lettre ?");
                str = Console.ReadLine();
                userInput = char.Parse(str);

                for(int i=0 ; i<hiddenWord.Length ; i++)
                {         
                    if(userInput == response[i])
                    {
                        continue;
                    }       
                    if(hiddenWord[i] == this.userInput)
                    {
                        toggle = true;
                        temp = new StringBuilder(response);
                        temp[i] = userInput;
                        response = temp.ToString();
                        break;
                    }
                }
                //Affichage du résultat de la tentative
                if(hiddenWord == response)
                {
                    win = true;
                    break;
                }
                else if(toggle)
                {
                    Console.WriteLine("Bien joué jeune homme !");
                }
                else 
                {
                    Console.WriteLine("Raté ! Réessaye");
                    score--;
                } 
            } 
        }
        //Vérifier le résultat et afficher le message finale
        public void CheckResult()
        {
            if(win)
            {
                Console.WriteLine("Vous avez trouvé le mot !\n" + response);
            }
            else
            {
                Console.WriteLine("Game Over...");
            }
        }
        public void play()
        {
            WordList();
            RandomWord();
            HideWord();
            CheckAnswer();
            CheckResult();
        }
        public static void Main()
        {
            Game game_01 = new Game();
            game_01.play();          
        }
    }
}

