//déclaration du mot et sa longueur
Console.WriteLine("Entrez le mot à trouver");
string mot = Console.ReadLine();
int tailleMot = mot.Length;

//Mise en tableau du mot


//déclaration du nombre d'erreures permisent
Console.WriteLine("Combien d'erreur sont tolérée?");
var nbr = int.Parse(Console.ReadLine());
int nbrErreur = nbr;

Console.Clear();
//Création du tableau pour stocker la solution 
string[] soluce = new string[tailleMot];
        for (int i=0; i < tailleMot; i++)
        {
            soluce[i] = " _";
        };

//Affichage du tableau et des information sur le mot
Console.WriteLine($"Trouver ce mot en {tailleMot} lettres");
Console.WriteLine(" ");
Console.WriteLine(" ");
for (int i=0; i <= soluce.Length-1; i++)
{
    Console.Write(soluce[i]);
}
Console.WriteLine(" ");
Console.WriteLine(" ");
Console.WriteLine($"il vous reste {nbrErreur} chances");
 
 while(nbrErreur>=0){  
    Console.WriteLine($"Il te reste {nbrErreur} chances");  
    --nbrErreur;  
}
Console.WriteLine("le mot était "+ mot +" et il faisait "+ tailleMot+ " lettres");

