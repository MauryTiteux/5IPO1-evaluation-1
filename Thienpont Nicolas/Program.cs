// See https://aka.ms/new-console-template for more information
using System.Collections;


// Interface de choix de la lettre à deviner !
string[] tableauMot =new string[]{"nulite", "ordinal", "manger", "repas", "analyse"};
Random rand = new Random();
int index = rand.Next(tableauMot.Length);
string mot= tableauMot[index];
var listLettres = new ArrayList();
var motADeviner = new ArrayList();
motADeviner.Add("Hello");

for(int i=0;i<mot.Length;i++){
    motADeviner.Add("- ");
}
Console.WriteLine(motADeviner);
string motADeviner2 = string.Join("",motADeviner);
Console.WriteLine(motADeviner2);

Console.WriteLine("-------------------------------------");
Console.WriteLine("Entrez la lettre à deviner :");
Console.WriteLine("-------------------------------------");
var entreeUtilisateur = Console.ReadLine();

