List<string> listMotPendu = new List<string> {"programation","pendu","objet","craie","australopitheque","bachibouzouk"};
var random = new Random();
int index = random.Next(listMotPendu.Count);                    //choisis un mot au hazard dans la liste
//Console.WriteLine(listMotPendu[index]);
string mot = listMotPendu[index];
List<string> lettreUsed = new List<string> { };
                             
char[] test3 = motPendu(mot);                                   //transforme le mot en tableau de lettre
string[] motArr = Array.ConvertAll(test3, x => x.ToString());   //convertis les lettre en string
                   
string[] motMasque = hiddenWord(motArr);                        // crée un tableau de meme longeur que le tableau des lettres du mot et le remplis de point


static void attempt(string[] arrMot, string[] arrMotCache, List<string> usedLettre, int count = 3, int occur = 0, int index = 0)
{
    do
    {
        for (int i = 0; i < arrMotCache.Length; i++)                // affiche le nombre de lettre du mot a trouvé
        {

            Console.Write(arrMotCache.GetValue(i));
        }

        Console.WriteLine("");
        Console.WriteLine("Lettre deja utilisée");
        usedLettre.ForEach(Console.Write);                          // affiche toute les lettres entrée par l'utilisateur
        Console.WriteLine("");
        Console.WriteLine("_______________");
        char lettreChar = Console.ReadKey().KeyChar;
        Console.WriteLine("");
        Console.WriteLine("");

        string lettreString = lettreChar.ToString();                // convertis le Char entré par l'utilisateur en string
        string indexString = index.ToString();                      // convertis la variable index en string
        usedLettre.Add(lettreString);                               // Ajouter la lettre entrée par l'utilsateur dans le tableau usedLettre

        bool bonneLettre = false;                                   // flag va me permettre de savoir si j'ai trouver une lettre correspondante ou pas
 
        for (int key = 0; key < arrMot.Length; key++)               // je boucle sur le tableau de mon mot a trouver
        {
            if (arrMot[key] == lettreString)                        // si la valeur de mon tableau mot a trouvera l'index "key" = la lettre entré par l'utilisateur
            {
                if (arrMotCache[key] == lettreString)               // si la valeur de mon tableau mot cacher a l'index "key" = la lettre entré par l'utilisateur
                {
                    if (!bonneLettre)                               // si cette lettre a deja ete rentré dans le tableau mot caché je signale a l'utilisateur qu'il l'a deja entré
                    {
                        Console.WriteLine("Vous avez deja entre cette lettre");
                    }
                }
                else                                                // si cette lettre n'a pas encore ete rentré dans le tableau mot caché
                {
                    if (!bonneLettre)                              // si cette lettre se trouve plusieurs fois dans le mot a trouver on ne signalera bonne lettre qu'une seul fois
                    {
                        Console.WriteLine("Bonne lettre");
                    }
                    arrMotCache[key] = arrMot[key];                 // on place la bonne lettre trouver au bon endroit dans le tableau mot caché
                    occur++;                                        // incrémentation d'une de mes deux condition de sortie
                    Console.WriteLine("");
                }
                bonneLettre = true;                                 // une bonne lettre a ete trouver => modification du booleen
                if (occur == arrMot.Length)                         // si tout le mot est trouver on le signal
                {
                    Console.WriteLine("Vous avez trouve le mot");
                    for (int i = 0; i < arrMotCache.Length; i++)    // affichage du mot trouvé
                    {
                        Console.Write(arrMotCache.GetValue(i));
                    }
                    Console.WriteLine("");
                }
            }
        }
        if (bonneLettre == false)                                          // si une mauvaise lettre a ete trouver j'ote une vie (deuxieme condition de sortie)
        {
            count--;
        }
        if (count == 0)                                             // si le nombre de vie est reduit a 0 "Game Over"
        {
            Console.WriteLine("Mauvaise lettre");
            Console.WriteLine("Game Over");
            Console.WriteLine("Le mot etait ");
            for (int i = 0; i < arrMot.Length; i++)                 // affichage du mot a trouver
            {

                Console.Write(arrMot.GetValue(i));
            }
            Console.WriteLine("");
        }
        if (bonneLettre == false && count != 0)                            // si une mauvaise lettre est trouver et qu'on a encore au moins 1 vie, affichage du message "mauvaise lettre" et du nombre de vie restant
        {
            Console.WriteLine("Mauvaise lettre essayer a nouveau");
            Console.WriteLine("Il vous reste " + count + " vie");
            Console.WriteLine("");
        }
        index++;
    } while (count != 0 && occur != arrMot.Length);                 // je boucle tant que j'ai des vie et que je n'ai pas trouver le mot caché
}

attempt(motArr, motMasque, lettreUsed);


static Char[] motPendu(string mot)                                  // fonction qui transforme un string en array string
{
    char[] nbLettre = new char[mot.Length];
    for (int i = 0; i < mot.Length; i++)
    {
        nbLettre[i] = mot[i];
    }
    return nbLettre;
}

static string[] hiddenWord(string []motArr)                         // fonction qui me renvoie un tableau remplis de point de la meme longeur qu'un autre tableau
{
    string[] motMasque = new string[motArr.Length];
    for (int i = 0; i < motMasque.Length; i++)
    {
        motMasque[i] = ".";
    }
    return motMasque;
}