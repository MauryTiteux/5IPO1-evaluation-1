//déclaration du mot et sa longueur
Console.WriteLine("Entrez le mot à trouver");
string mot = Console.ReadLine();

//Mise en tableau du mot
char[] motATrouver = new char[mot.Length];
for (int i=0; i <=motATrouver.Length-1; i++)
    {
        motATrouver[i]=mot[i];
    }


//déclaration du nombre d'erreures permisent
Console.WriteLine("Combien d'erreur sont tolérée?");
var nbr = int.Parse(Console.ReadLine());
int nbrErreur = nbr;
int erreur= 0;

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

while(bonneLettre<=mot.Length-1){  
//Affichage du tableau et des information sur le mot
    Console.Write($"Trouver ce mot de {mot.Length} lettres.                 Lettres déjà données:");
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
    Console.WriteLine($"il vous reste {nbrErreur} chances");
    Console.WriteLine(" ");
    Console.WriteLine($"entrer une lettre");
    string lettreInput = Console.ReadLine();
    char lettre; 
    char.TryParse(lettreInput, out lettre);
    Console.Clear();
    erreur=0;
    
//verif de la lettre 
    for(int j =0; j<=motATrouver.Length-1; j++){
//si lettre  bonne
        if(motATrouver[j]==lettre){
            if (soluce[j]==lettre){
                Console.WriteLine($"tu as déjà donné la lettre {lettre}");
            }
            else {
            Console.WriteLine($"tu as trouvé la lettre {lettre}");
            soluce[j]=lettre;
            ++bonneLettre;
            lettreDonne[numeroLettre] =lettre;
            numeroLettre++;
            }
        }
//si lettre mauvaise
        else{
            erreur++;
            if (erreur==mot.Length){
                nbrErreur--;
                lettreDonne[numeroLettre] =lettre;
                numeroLettre++;
                
            }
        }
    };
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
    Console.WriteLine($"il te restait {nbrErreur} chances");
    Console.WriteLine(" ");
}