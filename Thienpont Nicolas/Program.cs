﻿// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
using System;
using System.Text;

namespace JeuDuPendu
{
    internal class Program
    {

// Fonction permettant l'affichage du nombre d'erreur et du nombre d'essai restant pour le joueur.
// Condition vérifier le nombre d'erreur et affichant le bon message en fonction        
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


// Fonction initialisant les variables nécéssaires au bon fonctionnement du jeu.

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

// Fonction permettant d'afficher les tirets sous les lettres.
        private static void afficherLignes(string motAleatoire){
            Console.WriteLine("\r");
            foreach(char c in motAleatoire){
                Console.OutputEncoding = System.Text.Encoding.Unicode;
                Console.WriteLine("\u0305");
            }
        }


// Initialisation du jeu et choix du mot parmi ceux dans le tableau via un random.
// L'utilisation du random est spécial mais c'est mieux qu'en JS pour le coup.
        static void Main(string[] variable){
            Console.WriteLine("JEU DU PENDU !");
            Console.WriteLine("---------------------------------");
            Random aleatoire = new Random();
            List<string> dictionnaireDeMot = new List<string>{"maison", "manger","salut","accro","certain", "accord", "penal", "mechant", "or","hors"};
            int index = aleatoire.Next(dictionnaireDeMot.Count);
            string motAleatoire = dictionnaireDeMot[index];

            foreach(char x in motAleatoire){
                Console.WriteLine("_ ");
            }


// Initialisation de variables et tableaux.
            int longueurDuMot = motAleatoire.Length;
            int nombreErreur = 0;
            List<char> lettreDejaChoisie = new List<char>();
            int nombreDeLettresBonnes = 0;


// Vérification pour éviter que le jeu tourne en boucle.
            while(nombreErreur !=6 && nombreDeLettresBonnes != longueurDuMot){
                Console.WriteLine("\nLettres choisies depuis le début : ");
                foreach(char lettre in lettreDejaChoisie){
                    Console.WriteLine(lettre + " ");
                }
            }
        }
    }
}