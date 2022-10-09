Console.WriteLine("Entrez le mot à trouver");
string mot = Console.ReadLine();
int tailleMot = mot.Length;

Console.WriteLine("Combien d'erreur sont tolérée?");

var nbr = int.Parse(Console.ReadLine());
int nbrErreur = nbr;

Console.Clear();

string soluce;
int i;
for (i=0; i<tailleMot; i++){
  
};

 while(nbrErreur>=0){  
    Console.WriteLine("Il te reste "+ nbrErreur+ " chances");  
    --nbrErreur;  
}
Console.WriteLine("le mot était "+ mot +" et il faisait "+ tailleMot+ " lettres");

