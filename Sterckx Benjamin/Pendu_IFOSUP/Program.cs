// creation de la liste des mots a rechercher
using System;

List<string>listMot = new List<string> { "bonjour", "salut", "developpeur", "coucou", "pourquoi", "comment" };
string? rejouer = "";

// mode



while(rejouer == "") {
    Console.Clear();

    // initialisation du nombre de vie
    int nbVie = 0;

    // choisir un mode
    bool modeOk = false;
    
    while (!modeOk)
    {
        Console.WriteLine();
        Console.Write($"Choissisez un mode ( 1 = Facile , 2 = Moyen , 3 = difficile ) : ");
        if(int.TryParse(Console.ReadLine(),out int mode))
        {
            if(mode != 1 && mode != 2 && mode != 3)
            {
                modeOk = false;
            }
            else
            {
                switch (mode)
                {
                    case 1:
                        nbVie = 10;
                        break;
                    case 2:
                        nbVie = 7;
                        break;
                    case 3:
                        nbVie = 5;
                        break;
                    default:
                        // ne s'active jamais car tester au prealable
                        Console.WriteLine("nombre de vie invalide");
                        break;
                }
                modeOk = true;
                
            }
            
        }
        else
        {
            Console.WriteLine("valeur de mode incorrect !");
        }
        
    }

    Console.Clear();
    // initialisation du nombre de lettre trouvées
    int nbLetttreTrouve = 0;

    // creation d'un index pour chercher un mot aleatoirement dans la liste
    Random rand = new Random();
    int index = rand.Next(0, listMot.Count());


    // creation du tableau des lettres trouvée
    string[] listLettreTrouver = new string[listMot[index].Count()];

    // creation d'une liste pour les mauvaises lettres
    List<char> listMauvaiseLettre = new List<char>();

    // message pour les test a mettre en commentaire en production
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Mot a rechercher est {listMot[index]}");
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine();
    Console.WriteLine($"Le mot a trouver contient {listMot.Count()} lettres toutes en minuscle et pas d'accent !");
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.White;



    // affichage du nombre de caracter que contient le mot a trouver
    Console.Write("Mot a trouver : ");
    foreach (char item in listMot[index])
    {
        Console.Write(" _ ");
    }
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine($"Nombre de vie : {nbVie}");
    Console.WriteLine();


    // Lancement du jeu
    while (nbVie > 0 && nbLetttreTrouve < listMot[index].Length)
    {
        // Encodage utilisateur
       
        Console.Write("Encodez une lettre : ");
        string? lettre = Console.ReadLine();

        // test si le valeur encodée est valide n'est pas un chiffre
        while ( lettre != "a"
                && lettre != "b"
                && lettre != "c"
                && lettre != "d"
                && lettre != "e"
                && lettre != "f"
                && lettre != "g"
                && lettre != "h"
                && lettre != "i"
                && lettre != "j"
                && lettre != "k"
                && lettre != "l"
                && lettre != "m"
                && lettre != "n"
                && lettre != "o"
                && lettre != "p"
                && lettre != "q"
                && lettre != "r"
                && lettre != "s"
                && lettre != "t"
                && lettre != "u"
                && lettre != "v"
                && lettre != "w"
                && lettre != "x"
                && lettre != "y"
                && lettre != "z"
                )
        {
            Console.Write("Encodez une seule lettre, pas de chiffre, pas de majuscule et pas d'accents : ");
            lettre = Console.ReadLine();

        }

        
        //test si la lettre a deja été joué
        bool dejaJouer = false;
        while (!dejaJouer)
        {

            if (listLettreTrouver.Length > 0)
            {

                foreach (string item in listLettreTrouver)
                {
                    if (item == " " + lettre + " ")
                    {
                        dejaJouer = true;
                    }
                }
            }

            if (listMauvaiseLettre.Count() > 0)
            {

                if (char.TryParse(lettre, out char le))
                {

                    foreach (char item in listMauvaiseLettre)
                    {
                        if (item == le)
                        {
                            dejaJouer = true;
                        }
                    }

                }

            }

            if (dejaJouer)
            {
                Console.Write("Cette lettre a deja été joué encodez une nouvelle lettre : ");
                lettre = Console.ReadLine();
                dejaJouer = false;


            }
            else
            {
                dejaJouer = true;
            }
        }


        // verification et ajout si la lettre est dans le mot a trouver 
        if (char.TryParse(lettre, out char ch))
        {

            bool trouver = false;
            int i = 0;
            foreach (char l in listMot[index])
            {
                if (ch == l)
                {
                    //Console.Write($" {l} ");
                    listLettreTrouver[i] = " " + l + " ";
                    nbLetttreTrouve++;
                    trouver = true;
                }
                else
                {
                    if (listLettreTrouver[i] == null)
                        listLettreTrouver[i] = (" _ ");
                    //Console.Write(" - ");
                }

                i++;
            }
            if (!trouver)
            {
                nbVie--;
                trouver = false;
                listMauvaiseLettre.Add(ch);
                //Console.WriteLine();
                //Console.WriteLine($"La lettre n'est pas dans le mot vous perdez une vie ");
                //Console.WriteLine($"Nombre de vie(s) restante(s) : {nbVie}");
            }



            // afficher les lettres trouvées
            if (trouver)
            {
                Console.Clear();
                // message pour les test a mettre en commentaire en production
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Mot a rechercher est {listMot[index]}");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine($"Le mot a trouver contient {listMot.Count()} lettres toutes en minuscle et pas d'accent !");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.WriteLine("Lettres trouvées dans le mot");
                Console.WriteLine();
                foreach (string item in listLettreTrouver)
                {
                    Console.Write(item);
                }
                Console.WriteLine();
               
                if (listMauvaiseLettre.Count > 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Lettres jouées qui ne sont pas dans le mot");
                    Console.WriteLine();
                    foreach (char item in listMauvaiseLettre)
                    {
                        Console.Write($" {item} ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine($"Nombre de vie restante : {nbVie}");
                Console.WriteLine();
            }
            else
            {
                // affichage des lettres non trouvées
                if (listMauvaiseLettre.Count > 0)
                {

                    Console.Clear();
                    // message pour les test a mettre en commentaire en production
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Mot a rechercher est {listMot[index]}");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine();
                    Console.WriteLine($"Le mot a trouver contient {listMot.Count()} lettres toutes en minuscle et pas d'accent !");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();

                    Console.WriteLine("Lettres trouvées dans le mot");
                    Console.WriteLine();
                    foreach (string item in listLettreTrouver)
                    {
                        Console.Write(item);
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Lettres jouées qui ne sont pas dans le mot");
                    Console.WriteLine();
                    foreach (char item in listMauvaiseLettre)
                    {
                        Console.Write($" {item} ");
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine($"Nombre de vie restante : {nbVie}");
                    Console.WriteLine();
                }
            }


        }
        else
        {
            // message d'erreur qui ne devrait plus s'afficher vu que tout a été géré
            Console.WriteLine();
            Console.WriteLine("la conversion string vers char n'as pas fonctionné !");
        };

    }
    if (nbVie > 0)
    {
        // en cas de victoire
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("vous avez gagné");
        Console.ForegroundColor = ConsoleColor.White;
    }
    else
    {
        // en cas de defaite
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("vous avez perdu");
        Console.ForegroundColor = ConsoleColor.White;
      
    }

    // condition pour rejouer
    Console.WriteLine();
    Console.Write("Taper ENTER pour rejouer ou sur l'importe quel touche puis ENTER pour arreter :");
    rejouer = Console.ReadLine();
}
Console.WriteLine();
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Aurevoir et merci d'avoir jouer :) ");


enum Mode
{
    Facile = 1,
    Moyen = 2,
    Difficile = 3
}