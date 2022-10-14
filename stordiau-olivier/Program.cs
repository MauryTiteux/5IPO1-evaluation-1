// See https://aka.ms/new-console-template for more information

//////////////
/// PENDU ///
/////////////


// Pour le REGEX
using System.Text.RegularExpressions;


public class Pendu{
    

    // static void RandomWord() {

    
    // } 

    
    // Array avec les mots a trouver
    // string[] words = {"olivier", "michel", "seb"};
    string[] words = {"olivier"};
    // Nombres de vie
    int lives = 5;
    // Lettres du mot qu'il reste a deviné.
    int charCounter = 0;

    static void PrintMessages() 
    {
        //   Console.WriteLine("testestets");
        
    }
    
    public static void Main(string[] args) {

        Pendu myObj = new Pendu();
        
        string[] words = myObj.words;
        int lives = myObj.lives;
    
        
        // Prendre un mot random de l'array words
        string WordToGuess = words[new Random().Next(0, words.Length - 1)];
        
        // TOFIX n'accepte pas encore les mots/noms avec majuscules, espaces aussi ?
        // Limite userInput au charactères  a-z
        var validCharacters = new Regex("^[a-z]$");
        
        // Collection qui contient les lettres envoyer du client userInput, s'appellera key plus tard
        var letters = new List<string>();
       

        // Tant qu'il y ait des vies on continue
        while (lives != 0)
        {
            int charCounter = myObj.charCounter;
   
            // Boucle chaque lettre du WordToGuess
            foreach (var character in WordToGuess)
            {
                // Lettre transformé en string
                var letter = character.ToString();
                
                ///
                // Visuel du mot a trouver
                ///
                
            
                // On print la lettre si elle est dans l'array
                if (letters.Contains(letter))
                {
                    Console.Write(letter);
                }
                else
                {
                    // Les vides on ajoute _
                    Console.Write("_");
                    // On ajoute 1 par nombre de _ restant
                    charCounter++;
                }
            }
            Console.WriteLine(string.Empty);

            // Arrête la boucle si il ne reste pas de charactères
            if (charCounter == 0)
            {
                break;
            }


            // input Client de la lettre
            Console.Write("Vous avez Entrez la lettre ");

            // key contient la lettre input par le client convertit en minuscule (ToLower())
            // Console.ReadKey obtient prochain charactères ou fonction appuyer par l'utilisateur
            var key = Console.ReadKey().Key.ToString().ToLower();

            // Si on utilise pas ceci on a un doublon au niveau des lettres trouvés (liés au Console.WriteLine)
            Console.WriteLine(string.Empty);


            // Si elle ne respecte pas les règles regex 
            if (!validCharacters.IsMatch(key))
            {

                //  charactères invalide (chiffres etc..)
                Console.WriteLine($"\n\nLa lettre {key} est invalide. Réessayer.");
                // continue permet de continuer la boucle, break la stop
                continue;
            }


            // SI tu as déja entré cette lettre
            if (letters.Contains(key))
            {
                
                Console.WriteLine("\n\nVous avez déja entrer cette lettre");
                continue;
            }

            // Ajoute la lettre de l'input user si elle n'est pas encore intégrer
            letters.Add(key);

            // On enlève une vie si on se trompe de lettre
            // SI différent de WordToGuess alors
            if (!WordToGuess.Contains(key))
            {
                lives--;

                // Si il reste des vies on le montre
                if (lives > 0)
                {
                    Console.WriteLine($"\n\nLa lettre {key} n'est pas dans le mot. Vous avez {lives} vie restante.");
                }
            }
        }

        // Messages lorsqu'on a gagné
        if (lives > 0)
        {
            // print message gagné + vie restante
            Console.WriteLine($"\n\nVous avez gagné avec {lives} vie restante!");
        }
        else
        {
            // Message Perdu
            Console.WriteLine($"\n\nVous avez perdu le mot était '{WordToGuess}'.");   
        }

    }

    

}





