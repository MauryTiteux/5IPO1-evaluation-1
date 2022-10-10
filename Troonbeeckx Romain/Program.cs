string reponse;
string mot="base";
int nbrErreur=1;
for (int i =0; i<=15; i++) {
    Console.WriteLine("Voulez vous parametrez le jeu? oui = o ou non = n");
    reponse = Console.ReadLine();
//parametrage manuel
if(reponse=="o"){
//déclaration du mot et sa longueur
    Console.WriteLine("Entrez le mot à trouver");
    mot = Console.ReadLine();

//déclaration du nombre d'erreures permisent
    Console.WriteLine("Combien d'erreur sont tolérée?");
    var nbr = int.Parse(Console.ReadLine());
    nbrErreur = nbr;
    break;
}
//parametrage random
else if(reponse=="n"){
//création du tableau de mot
    string[] tabMot = {"arbre","Pharmacie","tableau","coucou","hibou","frigo","biere","ordinateur","pendu","ventilateur"};
//choix du mot au hasard
    Random aleatoire = new Random();
    int entier = aleatoire.Next(10);
    mot=tabMot[entier];
    Console.WriteLine(mot);
    for (int j =0; j<=15; j++) {
        Console.WriteLine("Choisissez votre niveau de dificulté: facile(8) = f, moyen(5) = m, difficile(2) = d");
        reponse = Console.ReadLine();

    if (reponse=="f"){
       nbrErreur = 8;
       break;
    }
    else if (reponse=="m"){
       nbrErreur = 5;
       break; 
    }
    else if (reponse=="d"){
       nbrErreur = 2;
       break;
    }
// reponse pas bonne    
    else{
        Console.WriteLine("Il faut choisir entre f, m ou d ...");
    }
    };
break;
}
// reponse pas bonne
else{
    Console.WriteLine("Il faut choisir entre oui ou non...");
}
};

//Mise en tableau du mot
char[] motATrouver = new char[mot.Length];
for (int i=0; i <=motATrouver.Length-1; i++)
    {
        motATrouver[i]=mot[i];
    }

Console.Clear();
//Création du tableau pour stocker la solution 
char[] soluce = new char[mot.Length];
        for (int i=0; i < mot.Length; i++)
        {
            soluce[i] =char.Parse("_");
        };

//tableau des lettres données
char[] lettreDonne= new char[26];
int numeroLettre =0;
int bonneLettre =0;
char lettre;
int erreur= 0;

while(bonneLettre<=mot.Length-1){  
//Affichage du tableau et des information sur le mot
    Console.Write($"Trouvez ce mot de {mot.Length} lettres.                 Lettres déjà données:");
    for (int i=0; i <= lettreDonne.Length-1; i++)
    {
        Console.Write(" "+lettreDonne[i]);
    }
    Console.WriteLine(" ");
    Console.WriteLine(" ");
    for (int i=0; i <= soluce.Length-1; i++)
    {
        Console.Write(" "+soluce[i]);
    }
    Console.WriteLine(" ");
    Console.WriteLine(" ");
    Console.WriteLine($"Il vous reste {nbrErreur} chances");
    Console.WriteLine(" ");
    Console.WriteLine($"Entrez une lettre");
    string lettreInput = Console.ReadLine(); 
    char.TryParse(lettreInput, out lettre);
    Console.Clear();
    erreur=0;
    if(lettreDonne.Contains(lettre)){
        Console.WriteLine($"Tu as déjà donné la lettre {lettre}.");
    }
    else{
            lettreDonne[numeroLettre] =lettre;
            numeroLettre++;
    }
//verif de la lettre 
    for(int j =0; j<=motATrouver.Length-1; j++){
//si lettre  bonne
        if(motATrouver[j]==lettre){
            if (soluce[j]==lettre){
            }
            else {
            Console.WriteLine($"Tu as trouvé la lettre {lettre}");
            soluce[j]=lettre;
            ++bonneLettre;
            }
        }
//si lettre mauvaise
        else{
            erreur++;
            if (erreur==mot.Length){
            nbrErreur--;
            }
        }
    };
//sortie de la boucle si plus de chance
    if (nbrErreur<=0){
        break;
    }
};

// si tu as perdu
if(nbrErreur<=0){
Console.WriteLine("Tu as perdu!");
Console.WriteLine($"Le mot était {mot}");
}
// si tu as gagné
else{
    Console.Write($"Bravo tu as trouvé le mot!!                   Lettres déjà données:");
    for (int i=0; i <= lettreDonne.Length-1; i++)
    {
        Console.Write(" "+lettreDonne[i]);
    }
    Console.WriteLine(" ");
    Console.WriteLine(" ");
    for (int i=0; i <= soluce.Length-1; i++)
    {
        Console.Write(" "+soluce[i]);
    }
    Console.WriteLine(" ");
    Console.WriteLine(" ");
    Console.WriteLine($"Il te restait {nbrErreur} chances");
    Console.WriteLine(" ");
}