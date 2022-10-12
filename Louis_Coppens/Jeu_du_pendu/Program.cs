using System;
using System.Collections.Generic;
using System.Diagnostics;
using static System.Formats.Asn1.AsnWriter;
using System.Drawing;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace jeu_du_pendu
{
    class Program
    {
        static void AfficherMot(string mot, List<char> lettres)
        {
            for (int i = 0; i < mot.Length; i++)
            {
                char lettre_unique = mot[i];
                if (lettres.Contains(lettre_unique))
                {
                    Console.Write($"{lettre_unique} ");
                }
                else
                {
                    Console.Write("_ ");
                }
            }
            Console.WriteLine();
        }

        static bool ToutesLettresDevinees(string mot, List<char> lettres)
        {
            foreach (var lettre in lettres)
            {
                mot = mot.Replace(lettre.ToString(), "");
            }
            if (mot.Length == 0)
            {
                return true;   
            }
            return false;
        }

        static char DemanderUneLettre()
        {
            Console.Write("Veuillez introduire une lettre : ");
            while (true)
            {
                string reponse = Console.ReadLine();
                if (reponse.Length == 1)
                {
                    reponse = reponse.ToUpper();
                    return char.Parse(reponse);
                }
                Console.WriteLine("ERREUR : Veuillez ne rentrer qu'une seule lettre");
            }
        }

        static void DevinerMot(string mot)
        {
            List<char> lettre_devine = new List<char> { };
            List<char> lettre_invalide = new List<char> { };
            const int NB_VIE = 6;
            int vie_restante = NB_VIE;
            while (vie_restante > 0)
            {
                Console.WriteLine(PENDU[NB_VIE - vie_restante]); 
                AfficherMot(mot, lettre_devine);
                Console.WriteLine();
                Console.WriteLine();
                var lettre = DemanderUneLettre();
                Console.Clear();
                if (mot.Contains(lettre))
                {
                    Console.WriteLine("cette lettre est dans le mot");
                    lettre_devine.Add(lettre);
                    Console.WriteLine($"Il vous reste {vie_restante} vie(s)");
                    if (ToutesLettresDevinees(mot, lettre_devine))
                    {
                        break;
                    }
                }
                else
                {
                    if (!lettre_invalide.Contains(lettre))
                    {
                        lettre_invalide.Add(lettre);
                        vie_restante--;
                    }
                    Console.WriteLine("la lettre ne se trouve pas dans le mot");
                    Console.WriteLine($"Il vous reste {vie_restante} vie(s)");
                }
                if (lettre_invalide.Count > 0)
                {
                    Console.WriteLine($"le mot ne contient pas les lettres : {string.Join(", ", lettre_invalide)}");
                }
                Console.WriteLine();
            }
            Console.Clear();
            Console.WriteLine(PENDU[NB_VIE - vie_restante]);
            if (vie_restante == 0)
            {
                Console.WriteLine($"Perdu le mot était : {mot}");
            } 
            else
            {
                AfficherMot(mot, lettre_devine);
                Console.WriteLine();
                Console.WriteLine("Gangé, vous avez trouvez le mot");
            }
        }

        static void Main(string[] args)
        {
            Random rnd = new Random();
            int random = rnd.Next(LISTE_DE_MOT.Length);
            string mot;
            string rejouer = "y";
            while (rejouer == "y")
            {
                Console.Clear();
                mot = LISTE_DE_MOT[random];
                DevinerMot(mot);
                Console.WriteLine();
                Console.WriteLine("voulez vous rejouer ? y/n");
                rejouer = Console.ReadLine();
            }
        }


        static string[] LISTE_DE_MOT = 
        {
            "ANGLE",
            "ARMOIRE",
            "BANC",
            "BUREAU",
            "CABINET",
            "CARREAU",
            "CHAISE",
            "CLASSE",
            "CLEF",
            "COIN",
            "COULOIR",
            "DOSSIER",
            "EAU",
            "ECOLE",
            "ENTRER",
            "ESCALIER",
            "ETAGERE",
            "EXTERIEUR",
            "FENETRE",
            "INTERIEUR",
            "LAVABO",
            "LIT",
            "MARCHE",
            "MATELAS",
            "MATERNELLE"
        };
        static string[] PENDU = { @"
  +---+
  |   |
      |
      |
      |
      |
=========",

@"
  +---+
  |   |
  O   |
      |
      |
      |
=========",

@"
  +---+
  |   |
  O   |
  |   |
      |
      |
=========",

@"
  +---+
  |   |
  O   |
 /|   |
      |
      |
=========",

@"
  +---+
  |   |
  O   |
 /|\  |
      |
      |
=========",

@"
  +---+
  |   |
  O   |
 /|\  |
 /    |
      |
=========",

@"
  +---+
  |   |
  O   |
 /|\  |
 / \  |
      |
=========
"
        };
    }
}
