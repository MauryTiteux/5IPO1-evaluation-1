// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
using System;
using System.Text;



/*
// Interface de choix de la lettre à deviner !
string[] tableauMot =new string[]{"nulite", "ordinal", "manger", "repas", "analyse"};
Random rand = new Random();

int index = rand.Next(tableauMot.Length);
string mot= tableauMot[index];

var listLettres = new ArrayList();
var motADeviner = new ArrayList();

for(int i=0;i<mot.Length;i++){
    motADeviner.Add("- ");
}

Console.WriteLine("-------------------------------------");
Console.WriteLine("Entrez la lettre à deviner :");
Console.WriteLine("-------------------------------------");
var entreeUtilisateur = Console.ReadLine();
*/
namespace JeuDuPendu
{
    internal class Program
    {
        private static void AffichagePendu(int erreurs)
        {
            if(erreurs==0){
                Console.WriteLine("Vous n'avez pas encore fait d'erreurs, il vous reste donc 6 essais !");               
            }
            else if(erreurs==1){
                Console.WriteLine("Vous avez fait 1 erreur, il vous reste 5 essais !");                           
            }
            else if(erreurs==2){
                 Console.WriteLine("Vous avez fait 2 erreurs, il vous reste 4 essais !");                              
            }
            else if(erreurs==3){
                 Console.WriteLine("Vous avez fait 3 erreurs, il vous reste 3 essai !");
            }
            else if(erreurs==4){
                Console.WriteLine("Vous avez fait 4 erreurs, il vous reste 2 essais !");            
            }
            else if(erreurs==5){
                Console.WriteLine("Vous avez fait 5 erreurs, il vous reste 1 essai !");
            }
            else if(erreurs==6){
                Console.WriteLine("Vous avez fait 6 erreurs, vous avez perdu !");
            }
        }

        private static int afficherMot(List<char>lettresADeviner, string motAleatoire){
            int compteur = 0;
            int bons = 0;
            Console.WriteLine("\r\n");
            foreach(char c in motAleatoire)
            {
                if(lettresADeviner.Contains((c)){
                    Console.WriteLine(c+" "); 
                    bons++;
                }
                else{
                    Console.WriteLine(" ");
                }
                compteur++;
            }
            return bons;
        }
        private static void afficherLignes(string motAleatoire){
            Console.WriteLine("\r");
            foreach(char c in motAleatoire){
                Console.OutputEncoding = System.Text.Encoding.Unicode;
                Console.WriteLine("\u0305");
            }
        }
    }
}