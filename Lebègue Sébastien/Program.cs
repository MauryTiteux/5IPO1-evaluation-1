using System.Text;

namespace HangMan
{
    public class Game
    {
        //Déclaration des variables publiques
        public string[] words ;
        public string response = "";
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
            this.words = new string[] {"chouffe", "duvel", "triple karmeliet", "orval", "barbar"};
        }
        //Choix du mot au hasard
        public void RandomWord()
        {
            this.random = new Random();
            randomIndex = random.Next(0, this.words.Length);
            this.hiddenWord = this.words[this.randomIndex];
        }
        //Création du visuel du mot caché
        public void HideWord()
        {
            for(int i=0 ; i<this.hiddenWord.Length ; i++)
            {
                if(Char.IsWhiteSpace(this.hiddenWord[i]))
                {
                    this.response += "   ";
                }
                else 
                {
                    this.response += "_ ";
                }
            }
        }
        //Verification si la lettre est presente dans le mot
        public void CheckAnswer()
        {
            this.score = 6;
            this.toggle = false;
            this.win = false;

            while(this.score != 0 || this.win == true)
            {
                this.toggle = false;
                Console.WriteLine("Tentatives restantes : " + this.score);
                Console.WriteLine(this.response + "\n");
                Console.WriteLine("Quelle lettre ?");
                this.str = Console.ReadLine();
                this.userInput = char.Parse(this.str);

                for(int i=0 ; i<this.hiddenWord.Length ; i++)
                {         
                    if(this.userInput == this.response[i])
                    {
                        continue;
                    }       
                    if(this.hiddenWord[i] == this.userInput)
                    {
                        this.toggle = true;
                        this.temp = new StringBuilder(this.response);
                        this.temp[i] = this.userInput;
                        this.response = this.temp.ToString();
                        break;
                    }
                }
                //Affichage du résultat de la tentative
                if(this.hiddenWord == this.response)
                {
                    this.win = true;
                }
                else if(this.toggle)
                {
                    Console.WriteLine("Bien joué jeune homme !");
                }
                else 
                {
                    Console.WriteLine("Raté ! Réessaye");
                    this.score--;
                } 
            } 
        }
        //Vérifier le résultat et afficher le message finale
        public void CheckResult()
        {
            if(this.win)
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

