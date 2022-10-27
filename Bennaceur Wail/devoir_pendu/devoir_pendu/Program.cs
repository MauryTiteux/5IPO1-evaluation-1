using System;

namespace pendu
{
    class Programe
    {

        static void AfficherMot(string mot, List<char> lettres)
        {
            for (int i = 0; i < mot.Length; i++)
            {
                char lettre = mot[i];
                if (lettres.Contains(lettre))
                {
                    Console.Write(lettre + " ");
                }
                else
                {
                    Console.Write(" _ ");
                }
            }
            Console.WriteLine();
        }

        static char DemanderLettre()
        {
            while (true)
            {
                Console.WriteLine("Soumet une lettre :");
                String LettreSoumis = Console.ReadLine();
                if (LettreSoumis.Length == 1)
                {
                    LettreSoumis = LettreSoumis.ToUpper();
                    return LettreSoumis[0];
                }
                Console.WriteLine("Tu n'as pas respecté la consigne petit filou !");
            }
        }
        static bool Resultat(string mot, List<char> lettres)
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

        static void DevinerMot(string mot)
        {
            var LettresDevinees = new List<char>();
            const int VieMax = 6;
            int ViesRestant = VieMax;

            while (ViesRestant > 0)
            {
                AfficherMot(mot, LettresDevinees);
                Console.WriteLine();
                var lettre = DemanderLettre();
                Console.Clear();

                if (mot.Contains(lettre))
                {
                    Console.WriteLine("cette lettre est dans le mot");
                    LettresDevinees.Add(lettre);
                    //Console.WriteLine("il te reste "+ ViesRestant+ " essais");
                    if (Resultat(mot, LettresDevinees))
                    {
                        //  Console.WriteLine("GG WP !!");
                        // return;
                        break;
                    }

                }
                else
                {
                    ViesRestant--;
                    Console.WriteLine("cettre lettre n'est pas dans le mot ");
                    Console.WriteLine("il te reste " + ViesRestant + " essais");
                }
                Console.WriteLine();
            }
            if (ViesRestant == 0)
            {
                Console.WriteLine("GAME OVER");
                Console.WriteLine("le mot que tu cherchais est : " + mot);

            }
            else
            {
                Console.WriteLine("GG WP !!");
            }
        }


        static void Main(string[] args)
        {
            Console.WriteLine("ecriver le mot ");
            string mot = Console.ReadLine();
            mot = mot.ToUpper();
            Console.Clear();
            DevinerMot(mot);
        }





    }


}